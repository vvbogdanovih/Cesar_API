namespace BLL.DTO
{
    public class Matrix
    {
        public int Size { get; private set; }
        public float[,] matrix { get; private set; }

        // base constructor
        public Matrix(int size)
        {
            Size = size;
            matrix = new float[Size, Size];
        }

        // copy constructor from base array
        public Matrix(float[,] arr)
        {
            Size = arr.GetLength(0);
            matrix = new float[arr.GetLength(0), arr.GetLength(1)];

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    matrix[i, j] = arr[i,j];
                }
            }
        }
        public Matrix(List<List<float>> arr)
        {
            Size = arr.Count;
            matrix = new float[arr.Count, arr.Count];
            // Проходимося по кожному рядку списку списків
            for (int i = 0; i < arr.Count; i++)
            {
                // Проходимося по кожному елементу в поточному рядку
                for (int j = 0; j < arr.Count; j++)
                {
                    // Копіюємо значення з списку у відповідний елемент масиву
                    matrix[i, j] = arr[i][j];
                }
            }
        }

        public Matrix(Matrix arr)
        {
            Size = arr.Size;
            matrix = new float[arr.Size, arr.Size];

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    matrix[i, j] = arr[i,j];
                }
            }
        }
        public float this[int i, int j]
        {
            get
            {
                if (i < 0 || i > Size || j < 0 || j > Size) throw new IndexOutOfRangeException("Index is out of range");
                return matrix[i, j];
            }
            set 
            {
                if (i < 0 || i > Size || j < 0 || j > Size) throw new IndexOutOfRangeException("Index is out of range");
                matrix[i, j] = value;
            }
        }

        // randomly fills matrix numbers from -25 to 25
        public void RandFil()
        {                     
            Random rnd = new Random();

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    matrix[i, j] = (float)Math.Round((float)(-25 + 50 * rnd.NextDouble()), 2);
                }
            }
        }

        // Returns determinant 2 by 2 matrix
        public static float Det2x2(Matrix a) => a[0, 0] * a[1, 1] - a[0, 1] * a[1, 0];

        // Returns Minor by element position in row
        public static Matrix GetMinor(Matrix a, int byPos)
        {
            Matrix b = new Matrix((a.Size - 1));
            int tempJ = 0;
            for (int i = 1; i < a.Size; i++)
            {
                for (int j = 0; j < a.Size; j++)
                {
                    if (byPos == j) continue;
                    b[i-1, tempJ] = a[i, j];
                    tempJ++;
                }
                tempJ = 0;
            }
            return b;
        }

        public float[,] ToFloat() => matrix;
        public List<List<float>> To2DList()
        {
            List<List<float>> listOfLists = new List<List<float>>();

            // Отримуємо розмірності двовимірного масиву
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            // Проходимося по рядках двовимірного масиву
            for (int i = 0; i < rows; i++)
            {
                // Створюємо новий список для поточного рядка
                List<float> rowList = new List<float>();

                // Проходимося по стовпцях двовимірного масиву
                for (int j = 0; j < cols; j++)
                {
                    // Додаємо елемент до списку рядка
                    rowList.Add(matrix[i, j]);
                }

                // Додаємо список рядка до основного списку списків
                listOfLists.Add(rowList);
            }

            // Повертаємо результат
            return listOfLists;
        }
    }
}
