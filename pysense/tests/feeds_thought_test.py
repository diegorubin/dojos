import unittest

# Biblioteca para criação de mocks
from unittest.mock import patch

# Classe que queremos testar
from feeds_thought import FeedsThought

from os.path import join, dirname

class FeedsThoughtTest(unittest.TestCase):

    # Código comum a todas as execuções
    def setUp(self):
        self.argv = ['think', 'feeds']

    # Exemplo de teste com mock
    #
    # @patch('feeds_thought.bar')
    # def test_foo(self, bar):
    #     # Para retornar um valor da mock
    #     bar.return_value = [ 1, 2 ]
    #
    #     # Verificar se um método foi chamado
    #     bar.assert_called_with(arg1, arg2)
    #
    #     # Recuperar os argumentos da função chamada
    #     bar.call_args[0]
    #
    #     # Assert simples
    #     self.assertEquals(1, 1)
    @patch("feeds_thought.all")
    @patch("feeds_thought.db")
    def test_list(self, db, all):
        feeds = [
            {
                'name': 'http://cherere.org',
                'value': [
                    'Naruto: Ep 1',
                    'Master Chef: Ep 3'
                ]
            }
        ]

        all.return_value = feeds

        thought = FeedsThought()
        result = thought.list(self.argv)

        self.assertEquals(feeds[0]["name"], result)

    @patch("feeds_thought.all")
    @patch("feeds_thought.db")
    def test_list_multi(self, db, all):

        feeds = [
            {
                'name': 'http://cherere.org',
                'value': [
                    'Naruto: Ep 1',
                    'Master Chef: Ep 3'
                ]
            },
            {
                'name': 'http://joselito.org',
                'value': [
                    'Um anime bom: Ep 1'
                ]
            }
        ]

        all.return_value = feeds

        thought = FeedsThought()
        result = thought.list(self.argv)

        self.assertEquals("http://cherere.org\nhttp://joselito.org", result)

    @patch("feeds_thought.db")
    @patch("feeds_thought.save_in_table")
    def test_add_save(self, save_in_table, db):
        self.argv.append('add')
        self.argv.append('http://jubirta.org')
        thought = FeedsThought()
        result = thought.add(self.argv)

        self.assertEquals('http://jubirta.org', result)
        self.assertEquals(save_in_table.call_args[0][1], 'http://jubirta.org')

    @patch('feeds_thought.notify')
    @patch("feeds_thought.db")
    @patch("feeds_thought.all")
    @patch("feeds_thought.Request")
    @patch('feeds_thought.urlopen')
    def test_run_notify_new_feed(self, urlopen, Request, all, db, notify):
        urlopen.return_value = self.__get_fixture()
        db_feeds = [
            {
                'name': 'http://cherere.org',
                'value': []
            }
        ]

        all.return_value = db_feeds

        thought = FeedsThought()
        thought.run()

        Request.assert_called_with('http://cherere.org', headers={'User-Agent': 'PySenseDaemon'})

        notification = notify.call_args[0]
        self.assertEquals(notification[0], 'http://cherere.org')
        self.assertEquals(notification[1], 'Naruto: Ep 1')

    @patch('feeds_thought.notify')
    @patch('feeds_thought.urlopen')
    @patch("feeds_thought.db")
    @patch("feeds_thought.all")
    def test_run_notify_only_new_feeds(self, all, db, urlopen, notify):
        urlopen.return_value = self.__get_fixture()

        db_feeds = [
            {
                'name': 'http://cherere.org',
                'value': [
                    'Naruto: Ep 1'
                ]
            }
        ]
        all.return_value = db_feeds

        thought = FeedsThought()
        thought.run()

        notification = notify.call_args[0]
        self.assertFalse('Naruto: Ep 1' == notification[1])


    def __get_fixture(self):
         fixture = join(dirname(__file__), 'fixtures', 'atom.xml')
         return open(fixture)
