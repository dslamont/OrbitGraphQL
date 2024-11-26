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
            //Tags
            Field<ListGraphType<TagDetailsType>> ("Tags").Description("Tag Collection").Resolve(x => tagService.GetTags());

            //Tag
            Field<ListGraphType<TagDetailsType>> ("Tag").Description("Individual Tag").Argument<IntGraphType>("id").Resolve (x => tagService.GetTag(x.GetArgument<int>("id")));
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
