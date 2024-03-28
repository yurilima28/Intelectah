Desenvolver uma pequena aplicação utilizando Asp.net MVC com as seguintes funcionalidades:
    1. Cadastro de Paciente (CRUD) onde a entidade deve conter as seguintes informações:
        ◦ Nome - Não pode ter mais que 100 caracteres
        ◦ CPF - Validar se CPF válido e se já existe CPF cadastrado na base para outro paciente
        ◦ Data de nascimento 
        ◦ Sexo
        ◦ Telefone - Não pode ser um telefone inválido
        ◦ E-mail - Não pode ser um e-mail inválido

    2. Cadastro de tipos de exame (CRUD) onde a entidade deve conter as seguintes informações:
        ◦ Nome do tipo de exame (ex: Hemograma, Raio X e etc) - Não pode ter mais que 100 caracteres
        ◦ Descrição - Não pode ter mais que 256 caracteres

    3. Cadastro de Exames (CRUD) onde a entidade deve conter as seguintes informações:
        ◦ Nome do exame - Não pode ter mais que 100 caracteres
        ◦ Observações - Não pode ter mais que 1000 caracteres
        ◦ Id do tipo de exame - Não pode ser nulo

    4. Marcação de consulta. O sistema deverá ter a opção de cadastrar uma consulta com as seguintes regras:
        ◦ Seleção de paciente cadastrado (Consultar por nome ou CPF). Caso não tenha cadastro, deverá exibir uma opção para redirecionar para tela de cadastro.
        ◦ Campo para seleção de tipo de exame que, após selecionado, irá carregar uma combo com os exames cadastrados para o tipo selecionado.
        ◦ Deverá ter data e hora e não poderá conflitar horários. Exemplo: Se informar um exame para o dia 23/11/2020 às 8:00 e o mesmo já estiver em uso em uma outra consulta o sistema não deverá permitir.
        ◦ Gerar número de protocolo único para a consulta
Após o término, subir o código para o github pessoal e nos enviar o link para análise.	
Observações:
    • Utilizar Aspnet MVC e EF (Entity Framework)
    • Utilizar um local DB ou SQL Server
    • Fazer uso de bootstrap no layout 
    • Se possível fazer o desenvolvimento em camadas 
