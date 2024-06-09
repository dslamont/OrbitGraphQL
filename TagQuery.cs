using GraphQL.Types;
using static OrbitGraphQL.TagModel;
using System.Xml.Linq;
using GraphQL;

namespace OrbitGraphQL
{
    public class TagQuery : ObjectGraphType
    {
        public TagQuery(ITagService tagService)
        {
            Field<ListGraphType<TagDetailsType>>(Name = "Tags", resolve: x => tagService.GetTags());
            Field<ListGraphType<TagDetailsType>>(Name = "Tag",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: x => tagService.GetTag(x.GetArgument<int>("id")));
        }
    }

    public class TagDetailsSchema : Schema
    {
        public TagDetailsSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<TagQuery>();
        }
    }
}
