using Npgsql;
using Publishing;
using PublishingSystem.Models; // Добавлено для Enum
using System;
using System.Windows.Forms;
using Npgsql.TypeMapping; // Для INpgsqlTypeMapper

namespace PublishingSystem.UI
{
    // Класс-транслятор для AgeRestriction
    class AgeRestrictionTranslator : INpgsqlNameTranslator
    {
        public string TranslateTypeName(string clrName) => "age_restriction"; // Имя типа в БД
        public string TranslateMemberName(string clrName)
        {
            // Преобразуем _0plus -> '0+', _6plus -> '6+' и т.д.
            return clrName.TrimStart('_').Replace("plus", "+");
        }
    }

    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Маппинг Enum'ов PostgreSQL на C# Enums
            NpgsqlConnection.GlobalTypeMapper.MapEnum<BookState>("book_state");
            NpgsqlConnection.GlobalTypeMapper.MapEnum<AgeRestriction>("age_restriction", new AgeRestrictionTranslator());

            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }
    }
}