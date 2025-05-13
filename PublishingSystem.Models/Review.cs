using System;

namespace PublishingSystem.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int IdCritic { get; set; }
        public int IdBook { get; set; }
        public DateTime DateTime { get; set; }
        public string Text { get; set; } // Для RichTextBox будем использовать Rtf
        public string RtfText { get; set; } // Сохраняем Rtf для форматирования
        public decimal GradeBook { get; set; }
        public decimal GradeCover { get; set; }

        // Свойства для отображения (заполняются через JOIN в репозитории)
        public string CriticName { get; set; }
        public string BookName { get; set; }
    }
}