# Conceitos


## Masstransit:

Framework Open Source de abstração para utilização de message broker. 
<br>Comunicação assíncrona.
<br>Foco no desacoplamento.
<br>Resiliente.
<br>Agendamento de Mensagem
<br>Monitoramento e log integrado


## RabbitMq:

https://www.youtube.com/watch?v=oA4xrvPnPYc&t=210s

Publisher -> Exchange -> Queue -> Consumer
<br> Publisher publica a mensagem para um Exchange:<br>


### Exchange
Analogia de um roteador, ele pega a mensagem e verifica de quem é a mensagem. Quem é a fila(queue) que ta ouvindo essa mensagem, então manda pra essa fila em questão
Forma mais inteligente de manda uma mensagem, voce nao pode enviar uma mensagem diretamente pra uma queue

**Tipos de Exchange**:
<br>**Direct**: Quando mensagem é enviada para uma fila específica
<br>**Fanout**: Quando mensagem é enviada para todas as filas que possuem BIND com a Exchange
<br>**Topic**: Quando mensagem é enviada para todas as filas de acordo com o ROUTING KEY configurada
<br>**Headers**: Quando mensagem é enviada de acordo com as regras implemetadas no header da mensagem

### Queues
**FIFO (First In, First Out)**: Primeira mensagem que entra é a primeira que sai
<br>**Propriedades**: 
<br>**Durable**: Se ela deve salvar mesmo depois do restart do broker (rabbitMq), nenhuma configuração (padrao)
<br>**Auto-delete**: Removida automaticamente quando consumer desconecta
<br>**Expiry**: Define o tempo que não há mensagens ou clientes consumindo, por exemplo definir que essa fila vai ta viva por um dia e após esse dia se nenhum consumer estiver mais ouvindo ela morre (Ultimo consumer desconectou, espera um dia e morre)
<br>**Message TTL**: Tempo de vida da mensagem. Jogou uma mensagem, se em 5 min ninguém consumiu... Deleta a mensagem
<br>**Dead Letter Queues**: Algumas mensagens não conseguem ser entregues por algum motivo. Foi feita a tentativa de entrega da mensagem pro consumidor, e deu erro, retentou algumas vezes e deu erro.
Essa mensagem vai pra Dead letter (UM EXCHANGE ESPECÍFICO), mensagem é colocada em um lugar específico pra ser tratada depois. Seja tratada por rotina, automatica ou manual



## Docker

docker-compose up -d

RabbitMq: http://localhost:15672

Jaeger http://localhost:16686/search