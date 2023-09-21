namespace Telerik.Scaffolders.Models.TreeList
{
    using System.ComponentModel.DataAnnotations;

    public class TreeListModel
    {
        [Editable(false)]
        public int Id { get; set; }
        [Editable(false)]
        public int? ParentId { get; set; }
        public string Name { get; set; }
    }
}

