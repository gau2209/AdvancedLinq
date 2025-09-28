namespace AdvanLinq
{
    internal class Program
    {
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
            // Left Join: Giống như Join, nhưng bao gồm tất cả các phần tử từ tập hợp bên trái, ngay cả khi không có phần tử tương ứng trong tập hợp bên phải.

            var leftJoinQuery = from student in Students
                                join score in Scores 
                                on student.ID equals score.StudentID into studentScores
                                from score in studentScores.DefaultIfEmpty()
                                select new { StudentID = student.ID, Name = student.Name, Score = score?.Score ?? 0 };

            foreach (var s in leftJoinQuery)
            {
                Console.WriteLine($"{s.StudentID} - {s.Name} - {s.Score}");
            }

            #endregion
        }
    }
}
