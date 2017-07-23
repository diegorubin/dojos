# Desconto Progressivo

## Descrição do Problema
Adaptado de http://codingdojo.org/kata/Potter/

Um grande ecommerce pretende realizar uma promoção com desconto progressivo para
uma série composta por 5 livros.

Uma cópia de qualquer um dos cinco livros custa R$ 16,00. Se, no entanto, você 
comprar dois livros diferentes da série, você obtém um desconto de 5% nesses dois 
livros. Se você comprar 3 livros diferentes, obtém um desconto de 10%. 
Com 4 livros diferentes, você recebe um desconto de 20%. 
E caso compre todos os 5, você obtém um enorme desconto de 25%.

Note-se que, se comprar, digamos, quatro livros, dos quais 3 são títulos 
diferentes, obtém um desconto de 10% nos 3 que fazem parte de um conjunto, 
mas o quarto livro ainda custa R$ 16,00.

Esse ecommerce pediu para escrever um código que dado uma lista de livros
calcule o valor da compra.

__Por exemplo, quanto esse carrinho?__

2 cópias do primeiro livro
2 cópias do segundo livro
2 cópias do terceiro livro
1 cópia do quarto livro
1 cópia do quinto livro

__Resposta__

(5 \* 16) - 25% \[primeiro livro, segundo livro, terceiro livro, quarto livro, quinto livro\]

\+ (3 \* 16) - 10% \[primeiro livro, segundo livro, terceiro livro\]

= 103,20

