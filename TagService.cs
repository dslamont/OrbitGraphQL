using static OrbitGraphQL.TagModel;

namespace OrbitGraphQL
{
    public interface ITagService
    {
        public List<TagDetails> GetTags();

        public List<TagDetails> GetTag(int tagId);

        public List<TagDetails> GetTagsByUnit(int unitId);
    }

    public class TagService : ITagService
    {
        public TagService()
        {

        }
        private List<Tag> tags = new List<Tag>
        {
            new Tag(1, "Tag 1", 1),
            new Tag(2, "Tag 2", 1),
            new Tag(3, "Tag 3", 2),
            new Tag(4, "Tag 4", 2),
            new Tag(5, "Tag 5", 3),

        };

        private List<Unit> units = new List<Unit>
        {
            new Unit(1, "Unit 1"),
            new Unit(2, "Unit 2"),
            new Unit(3, "Unit 3"),
        };

        public List<TagDetails> GetTags()
        {
            return tags.Select(tag => new TagDetails
            {
                Id = tag.Id,
                TagNo = tag.TagNo,
                UnitId = units.First(d => d.Id == tag.unitId).Id,
            }).ToList();

        }
        public List<TagDetails> GetTag(int tagId)
        {
            return tags.Where(tag => tag.Id == tagId).Select(tag => new TagDetails
            {
                Id = tag.Id,
                TagNo = tag.TagNo,
                UnitId = units.First(d => d.Id == tag.unitId).Id,
            }).ToList();
        }

        public List<TagDetails> GetTagsByUnit(int unitId)
        {
            return tags.Where(tag => tag.unitId== unitId).Select(tag => new TagDetails
            {
                Id = tag.Id,
                TagNo = tag.TagNo,
                UnitId = units.First(d => d.Id == unitId).Id,
            }).ToList();
        }
    }
}
