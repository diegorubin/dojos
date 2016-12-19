import unittest

# Biblioteca para criação de mocks
from unittest.mock import patch

# Classe que queremos testar
from feeds_thought import FeedsThought

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

    def test_list(self):
        pass

