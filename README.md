API Academia

Este projeto possui endpoints para cadastrar **alunos** e **aulas**.  
Alguns campos utilizam **enums** para identificar tipos de planos e tipos de aula.  

Os valores devem ser enviados como `números inteiros` no corpo da requisição.

Cadastro de Aluno
Endpoint: POST /api/alunos  

Exemplo de body:
json
{
  "nome": "João",
  "tipoPlano": 1
}
Cadastro de Aula
Endpoint: POST /api/aula

Exemplo de body:
json
{
  "tipoAula": 1,
  "dataHora": "2025-10-20T09:00:00",
  "capacidadeMaxima": 5
}

Você também pode visualizar todos os valores do Enum diretamente na documentação do Swagger;

