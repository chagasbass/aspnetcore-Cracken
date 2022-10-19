# Aspnetcore-Cracken
![img](https://images.rawpixel.com/image_600/czNmcy1wcml2YXRlL3Jhd3BpeGVsX2ltYWdlcy93ZWJzaXRlX2NvbnRlbnQvbHIvdjk5LWJpbm4tbmluZy01NC1pbGx1c3RyYXRpb24uanBn.jpg)

[[_TOC_]]
##**Extensions criadas para  apis do tipo Minimal**

# Restoque-Template-API 
Template para projetos do tipo Web-Api usando as premissas de arquitetura do projeto base. Este template foi feito para facilitar o desenvolvimento das apis e futuros microserviços, dando mais velocidade nas entregas, pois abstrai os conceitos básicos da construção da arquitura proposta, deixando o tempo livre para resolução do negócio da melhor forma.
Projeto foi criado na versão 6.0 (LTS) do AspnetCore.

# IMPORTANTE
1. Sempre que um projeto seja criado a partir do template, suas dependências devem ser atualizadas para que os pacotes usados sejam sempre os mais novos.
2. O Arquivo DockerFile é sempre gerado com os projetos das camadas defaults da aplicação, caso seja criada alguma camada adicional, deve-se colocar manualmente o caminho no arquivo.

##**Versão 1.0.3**
A nova versão do template contém as seguintes features:

1.	Configuração do **Serilog** para captura de Logs estruturados.
2.	Configuração do **Serilog** para envio dos logs gerados para o **Application Insights**.
3.  Interface e implementação do serviço de logs estruturados.
4.  Middleware do Serilog para recuperar o **body das requisições** recebidas pela api.**(SerilogRequestLoggerMiddleware)**
5.  Middleware para tratamento de **Exceptions Globais** na aplicação.**(GlobalExceptionHandlerMiddleware)**
6.  Middleware para tratamento de **ProblemDetails nos StatusCode 401** da api.**(UnauthorizedTokenMiddleware)**
7.	Contexto de dados para uso do MicroOrm **Dapper** em conjunto com o pacote **Dapper.Contrib**
8.	Projeto de testes de unidade configurados para usar as bibliotecas **MOQ,Autofixture**.
9.  Extensão para resolução de dependência da aplicação.**(DependencyInjectionExtensions)**
10. Extensão para **autenticação via SSO**. **(AuthenticationExtensions)**
11. Extensão para acesso a configurações usando o padrão Options Pattern. **(OptionsExtensions)**
12. Extensão de **Healthcheck para monitoramento da aplicação.** **(HealthcheckExtensions)**
13. Extensão de **Healthcheck para monitoramento de consumo de memória.** **(GarbageCollectorHealthcheck)**. 
14. Extensão de performance para request usando compactadores de requisição (Brotli, Gzip). **(PerformanceApiExtensions)**
15. Extensão de documentação da api usando Swagger(Open API).**(SwaggerExtensions)**
16. Extensão para versionamento de apis por rotas em conjuto com  Swagger(Open API).**(VersioningExtensions)**
17. Extensão de observabilidade usando **Application Insights**.**(TelemetryExtensions)**
18. Opção de Inserção de autenticação na documentação do Swagger. **(SwaggerExtensions)**
19. Implementação do padrão de notificações aplicação **Notification Pattern**. 
20. Uso do retorno customizado de erros **ProblemDetails** para erros da aplicação.
21. Extensão para o tratamento de resiliência usando o Pattern **Retry**. **(ResilienceExtensions)**
22. Adição do filtro para parâmetros não obrigatórios em rotas da api.
23. Adição dos arquivos de **GlobalUsings** em cada camada da aplicação contendo as referências usadas no projeto.
24. Adição dos **Scoped Namespaces** em todos os arquuivos do template.
25. Adição do arquivo **xunit.runner.json** para nomenclatura de testes no gerenciador de testes da IDE.
26. Uso do retorno padrão customizado  **ICommandResult/CommandResult** na api.

# Middlewares e Extensões

**<h2>Middlewares</h2>**

Os Middlewares são sempre inseridos dentro do arquivo Startup.cs no método Configure. Caso exista a necessidade de criação de um novo Middleware será dentro desse método que devemos inserí-lo. Dentro do ASPNET CORE existem uma
**ordem de execução dos middlewares**, para saber mais sobre consulte a documentação.



