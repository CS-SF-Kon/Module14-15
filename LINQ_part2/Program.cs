namespace LINQ_part2;

internal class Program
{
    static void Main(string[] args)
    {
        var classes = new[]
        {
               new Classroom { Students = {"Evgeniy", "Sergey", "Andrew"}, },
               new Classroom { Students = {"Anna", "Viktor", "Vladimir"}, },
               new Classroom { Students = {"Bulat", "Alex", "Galina"}, }
           };
        var allStudents = GetAllStudents(classes);

        Console.WriteLine(string.Join(" ", allStudents));
    }

    /// <summary>
    /// Метод, возвращающий массив имён студентов из всех экземпляров, содержащихся в оригинальном массиве
    /// </summary>
    /// <param name="classes"></param>
    /// <returns></returns>
    static string[] GetAllStudents(Classroom[] classes)
    {
        string[] names = classes.SelectMany(x => x.Students).ToArray();

        // ВАУ, получается, действительно почти любую операцию можно реализовать и через методы расширения, и через операторы запросов. Осталось только выучить...

        //string[] names = (from c in classes
        //                  from v in c.Students
        //                  select v).ToArray

        return names;
    }
}
