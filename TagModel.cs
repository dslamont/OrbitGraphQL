using GraphQL.Types;

namespace OrbitGraphQL
{
    public class TagModel
    {
        public record Tag(int Id, string TagNo, int unitId);

        public record Unit(int Id, string Name);

        public class TagDetails
        {
            public int Id { get; set; }
            public string TagNo { get; set; }
            public int UnitId { get; set; }
        }

        public class TagDetailsType : ObjectGraphType<TagDetails>
        {
            public TagDetailsType()
            {
                Field(x => x.Id);
                Field(x => x.TagNo);
                Field(x => x.UnitId);
            }
        }
    }
}
