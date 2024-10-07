using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var db = builder.AddPostgres("db").WithPgAdmin();
var todosdb = db.AddDatabase("todosdb");


var todos = builder.AddProject<Projects.TodoListProject_Web>("TodoList")
    .WithReference(todosdb);


var apiService = builder.AddProject<Projects.TodoListProject_ApiService>("apiservice");

builder.AddProject<Projects.TodoListProject_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();
