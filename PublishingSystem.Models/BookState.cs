namespace PublishingSystem.Models
{
    public enum BookState
    {
        in_progress,    // В работе (автор)
        editing,        // Редактирование (редактор)
        ready_to_print, // Готово к печати (после дизайнера)
        published       // Опубликовано
    }
}