
using GraphQL.Types;
using GraphQL;
using static OrbitGraphQL.TagModel;

namespace OrbitGraphQL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<ITagService, TagService>();
            builder.Services.AddSingleton<TagDetailsType>();
            builder.Services.AddSingleton<TagQuery>();
            builder.Services.AddSingleton<ISchema, TagDetailsSchema>();
            builder.Services.AddGraphQL(b => b
                .AddAutoSchema<TagQuery>()  // schema
                .AddSystemTextJson());   // serializer
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            //builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

            var app = builder.Build();

            //// Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapGraphQL();
            }
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.MapGet("/", () => "GraphQL Example");


            app.UseGraphQL<ISchema>("/graphql");            // url to host GraphQL endpoint
            //app.UseGraphQLPlayground(
            //    "/",                               // url to host Playground at
            //    new GraphQL.Server.Ui.Playground.PlaygroundOptions
            //    {
            //        GraphQLEndPoint = "/graphql",         // url of GraphQL endpoint
            //        SubscriptionsEndPoint = "/graphql",   // url of GraphQL endpoint
            //    });

            app.UseGraphQLGraphiQL();

            app.Run();
        }
    }
}
