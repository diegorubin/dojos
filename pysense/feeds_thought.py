# Para realizar requests http
#
# Um simples get pode ser realizado através do seguinte código
#
# request = Request(url, headers={'User-Agent': 'PySenseDaemon'})
# content = urlopen(request).read()
from urllib.request import Request, urlopen

# Biblioteca para manipular xml
#
# Usaremos o formato atom de feeds neste problema
#
# Para recuperar o título do feed
# DOMTree = xml.dom.minidom.parseString(content)
# document = DOMTree.documentElement
# document.getElementsByTagName('title')[0].firstChild.data
#
# Para recuperar as noticias
# document.getElementsByTagName('item'):
import xml.dom.minidom

# Recursos do pysense
#
# Notificar utilizando o sistema de notificação padrão do gnome
# notify(title, subtitle, file_image)
from pysense.actions import notify

# Classe base dos pensamentos
from pysense.thought import ThoughtBase

# Funções para manipular o banco de dados
#
# db -> referencia para o banco de dados global
# db.table(name) -> recuperar tabela especifica deste pensamento
# all -> função que retorna todas as entrada de uma tabela, ex:
# all(db.table(name)
# save_in_table -> salva as informações na tabela, se houver uma entrada para a
# chave utilizada, a entrada será sobrescrita, ex:
# save_in_table(db.table(name), name, value)
from pysense.memories import db, all, save_in_table

class FeedsThought(ThoughtBase):

    # Método que é executado quando o processo é agendado
    def run(self):
        pass

    # Listar feeds cadastrados:
    # Para executar o método: think feeds list
    # O retorno do método sempre deve ser uma string
    def list(self, argv):
        return ''

    # Adicionar um feed:
    # Para executar o método: think feeds add <url>
    # O retorno do método sempre deve ser uma string
    def add(self, argv):
        return ''

# Essa função é executada na inicialização do pensamento
def init():
    thought = FeedsThought()
    thought.schedule(after=60)
    return thought

