namespace LINQ_part1;

internal class Program
{
    static void Main(string[] args)
    {
        var phoneBook = new List<Contact>
        {
            new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"),
            new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"),
            new Contact("Сергей", "Брин", 799900000013, "serg@example.com"),
            new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"),
            new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"),
            new Contact("Вася", "Петечкин", 799900000014, "vasyan@example.com"),
            new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"),
            new Contact("Червь", "Игорь", 799900000014, "chervigor@example.com"), // добавил ещё конаткты, пересортировал и увеличил число записей на одной странице до трёх для наглядности 
            new Contact("Петя", "Васечкин", 799900000013, "pitrusha@example.com")
        };

        while (true)
        {
            var input = Console.ReadKey().KeyChar;

            var parsed = Int32.TryParse(input.ToString(), out int pageNumber);

            if (!parsed || pageNumber < 1 || pageNumber > 3)
            {
                Console.WriteLine();
                Console.WriteLine("Страницы не существует");
            }
            else
            {
                var pageContent = phoneBook.Skip((pageNumber - 1) * 3).Take(3); // ВАУ, это же как работа с датафреймами в пандасе на питоне, только ещё удобнее, понятнее и поддерживается нативно
                Console.WriteLine();

                //var sortedPage = pageContent.OrderBy(s => s.Name).ThenBy(s => s.LastName); // через запросы

                var sortedPage = from c in pageContent orderby c.Name, c.LastName select c; // через методы расширения

                foreach (var entry in sortedPage)
                    Console.WriteLine(entry.Name + " " + entry.LastName + ": " + entry.PhoneNumber);

                Console.WriteLine();
            }
        }

    }
}
