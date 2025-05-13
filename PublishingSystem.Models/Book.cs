using System;

namespace PublishingSystem.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdAuthor { get; set; }
        public int? IdEditor { get; set; }
        public int? IdDesigner { get; set; }
        public BookState State { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EstimatedEndDate { get; set; }
        public AgeRestriction AgeRestrictions { get; set; }
        public string CoverImagePath { get; set; }
        public DateTime? PublishDate { get; set; }

        // Свойства для отображения имен (заполняются через JOIN в репозитории)
        public string AuthorName { get; set; }
        public string EditorName { get; set; }
        public string DesignerName { get; set; }

        // Свойство для отображения статуса в DataGridView
        public string StateDisplay => State.ToString().Replace("_", " ");
        // Свойство для отображения ограничения в DataGridView
        public string AgeRestrictionDisplay => AgeRestrictions.ToString().Replace("_", "").Replace("plus", "+");
    }
}