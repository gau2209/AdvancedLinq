namespace AdvanLinq
{
    internal class Program
    {
        public class Employee
        {
            public string Location { get; set; }
            public string Name { get; set; }
            public string Department { get; set; } // HR , IT, Sales
            public double Salary { get; set; }
        }

        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var Students = new[]
            {
                new {ID = 1, Name = "Anh Tuấn" },
                new {ID = 2, Name = "Hoàng" },
                new {ID = 3, Name = "Hẹ hẹ" },
                new {ID = 4, Name = "cục cứt" },
                new {ID = 5, Name = "con lktaw" },
            };

            var Scores = new[]
            {
                new {StudentID = 1, Score = 5.6f },
                new {StudentID = 2, Score = 5.7f },
                new {StudentID = 3, Score = 5.8f },
                new {StudentID = 4, Score = 5.9f },
            };

            #region Join
            //// Join: Kết hợp hai tập hợp dựa trên một khóa chung.



            //var query = from student in Students
            //            join score in Scores
            //            on student.ID equals score.StudentID
            //            select new { StudentID = student.ID, Name = student.Name, Score = score.Score };

            //foreach (var s in query)
            //{
            //    Console.WriteLine($"{s.StudentID} - {s.Name} - {s.Score}");
            //}
            #endregion

            #region Left Join
            //// Left Join: Giống như Join, nhưng bao gồm tất cả các phần tử từ tập hợp bên trái, ngay cả khi không có phần tử tương ứng trong tập hợp bên phải.

            //var leftJoinQuery = from student in Students
            //                    join score in Scores 
            //                    on student.ID equals score.StudentID into studentScores
            //                    from score in studentScores.DefaultIfEmpty()
            //                    select new { StudentID = student.ID, Name = student.Name, Score = score?.Score ?? 0 };

            //foreach (var s in leftJoinQuery)
            //{
            //    Console.WriteLine($"{s.StudentID} - {s.Name} - {s.Score}");
            //}

            #endregion

            #region Take và Skip
            //// Take và Skip: Lấy hoặc bỏ qua một số phần tử từ tập hợp.
            //var ListNumber = Enumerable.Range(1, 20);
            //var takeQuery = ListNumber.Take(5); // Lấy 5 phần tử đầu tiên
            //Console.WriteLine("Take:" + string.Join(", ",takeQuery));

            //var skipQuery = ListNumber.Skip(10); // Bỏ qua 10 phần tử đầu tiên
            //Console.WriteLine("Skip: " + string.Join(", ", skipQuery));

            //var takeLastQuery = ListNumber.TakeLast(5); // Lấy 5 phần tử cuối cùng
            //Console.WriteLine("Take last: " +string.Join(", ", takeLastQuery));

            //var skipLastQuery = ListNumber.SkipLast(10); // Bỏ qua 10 phần tử cuối cùng

            //Console.WriteLine("Skip last: " +string.Join(", ", skipLastQuery));

            //var takeWhileQuery = ListNumber.TakeWhile(n => n < 10); // Lấy phần từ nhỏ hơn 10
            //Console.WriteLine("Take while: " +string.Join(", ", takeWhileQuery));

            //var skipWhileQuery = ListNumber.SkipWhile(n => n < 10); // Bỏ qua phần tử nhỏ hơn 10

            //Console.WriteLine("Skip while: " +string.Join(", ", skipWhileQuery));

            #endregion

            #region GroupBy với 1 khoá
            //// GroupBy với 1 khoá: Nhóm các phần tử dựa trên một thuộc tính duy nhất.
            //// Sau khi group by thì kết quả trả về là một tập hợp các nhóm và key của nhóm đó
            //var people = new[]
            //{
            //    new { Name = "Alice", Age = 30 },
            //    new { Name = "Bob", Age = 25 },
            //    new { Name = "Charlie", Age = 30 },
            //    new { Name = "David", Age = 25 },
            //    new { Name = "Eve", Age = 35 }
            //};
            //var groupByAge = from person in people
            //                 group person by person.Age into ageGroup
            //                 select new { Age = ageGroup.Key, People = ageGroup.ToList() };


            //var groupByAge2 = people.GroupBy(p => p.Age);
            //foreach (var ps in groupByAge2)
            //{
            //    Console.WriteLine($"Age: {ps.Key} ");
            //    foreach (var p in ps)
            //    {
            //        Console.WriteLine($"Name: {p.Name} - Age{p.Age}Ư");
            //    }
            //}
            #endregion

            #region GroupBy với 2 khoá
            
            
          var employees = new[]
            {
                new Employee { Name = "Alice", Location = "New York", Department = "HR", Salary = 60000 },
                new Employee { Name = "Bob", Location = "New York", Department = "IT", Salary = 80000 },
                new Employee { Name = "Charlie", Location = "Los Angeles", Department = "HR", Salary = 65000 },
                new Employee { Name = "David", Location = "Los Angeles", Department = "IT", Salary = 90000 },
                new Employee { Name = "Eve", Location = "New York", Department = "Sales", Salary = 70000 },
                new Employee { Name = "Frank", Location = "Los Angeles", Department = "Sales", Salary = 72000 },
                new Employee { Name = "Tuấn", Location = "New York", Department = "IT", Salary = 72000 }
            };
            #endregion

            var groupBy_Department_And_Location = employees.GroupBy(e => new { e.Department, e.Location })
                .Select(g => new
                {
                    Department = g.Key.Department,
                    Location = g.Key.Location,
                    TotalSalary = g.Sum(e => e.Salary),
                    Employees = g.ToList()
                });

            foreach (var item in groupBy_Department_And_Location)
            {
                Console.WriteLine($"Department {item.Department}, location: {item.Location}");
                Console.WriteLine($"Total salary: {item.TotalSalary}");
                foreach (var emp in item.Employees)
                {
                    Console.WriteLine($" - {emp.Name}, Salary: {emp.Salary}");
                }
            }
        }
    }
}
