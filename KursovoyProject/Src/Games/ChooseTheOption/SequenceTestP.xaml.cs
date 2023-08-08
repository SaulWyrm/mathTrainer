using KursovoyProject.Src.Games.Operations;
using KursovoyProject.Src.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KursovoyProject.Src.Games.ChooseTheOption
{
    /// <summary>
    /// Interaction logic for ChooseTheOptionP.xaml
    /// </summary>
    static class LinqExtensions
    {
        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> list, int parts)
        {
            int i = 0;
            var splits = from item in list
                         group item by i++ % parts into part
                         select part.AsEnumerable();
            return splits;
        }
    }
    public static class Extensions
    {
        public static List<List<T>> partition<T>(this List<T> values, int chunkSize)
        {
            return values.Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }
    public partial class SequenceTestP : Page
    {
        private void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            var page2 = new SequenceP();
            NavigationService.Navigate(page2);
        }
        

        public void setTemplate(string path)
        {
            string template =
            @"---Введите свой вопрос или задание в пустой строке ниже
Заполнитель вопроса
---Введите возле каждого пункта ответ к заданию(правильный ответ пометить знаком '!')
1. -
2. -
3. -
4. -
--- (Остальные вопросы записываются таким же образом [строки с черточками можно не указывать])";



            try
            {
                if (Process.GetProcessesByName("notepad++").Length > 0)
                {
                    var process = Process.GetProcessesByName("notepad++")[0];
                    var appPath = process.MainModule.FileName;
                    process.Kill();
                    File.WriteAllText(path, template);
                    Process.Start(appPath);

                }
                else
                {
                    File.WriteAllText(path, template);
                }
            }
            catch
            {
                MessageBox.Show("Файл используется посторонним процессом, программа не может автоматически исправить файл. \nПоэтому исправьте синтаксис вручную, информация о синтаксисе упомянуто в справочной информации под разделов \"Тест и тренажер\"");
                System.Windows.Application.Current.Shutdown();
            }


        }

        public bool ContainsAny(string s, List<string> substrings)
        {
            if (string.IsNullOrEmpty(s) || substrings == null)
                return false;

            return substrings.Any(substring => s.Contains(substring));
        }

        public List<string> questions = new List<string>();
        public List<string> allAnswers = new List<string>();
        public List<string> correctAnswers = new List<string>();

        public List<string> separatorSymbols = new List<string>()
            {" ","-",",",@"\","|","~",">","<"};


        public SequenceTestP()
        {

            InitializeComponent();
            MainWindow.i = 1;
            string path = System.AppDomain.CurrentDomain.BaseDirectory;

            var testPath = path + @"TestFiles\Questions.txt";
            checkFile(testPath);

            addNew();



        }



        public void checkFile(string path)
        {
            if (!File.Exists(path))
            {
                setTemplate(path);
            }

            var usualPattern = @"^\d+\.\s*.*\s*$";
            var questionPattern = @"^(?!\s|\d\.|\,|\-|\~|\>|\<|\||\+|\=|\#|\$|\%|\^|\&|\*).+";

            using (StreamReader file = new StreamReader(path))
            {
                string ln;
                Match mq, ma;
                int ansNum = 0;
                while ((ln = file.ReadLine()) != null)
                {
                    mq = Regex.Match(ln, questionPattern);
                    ma = Regex.Match(ln, usualPattern, RegexOptions.Multiline);

                    
                    if (mq.Success)
                    {
                        questions.Add(mq.Value);
                        MainWindow.numberQuestions++;
                        for (int i=0; i < 4; i++)
                        {
                            correctAnswers.Add(" ");
                        }
                        
                    }
                    else if (ma.Success)
                    {
                        
                        var buf = ma.Value.Split(new[] { '.' }, 2)[1].ToString().Trim();
                        var before = ma.Value.Split('.')[0].ToString().Trim();
                        if (buf == "" || buf == " ")
                        {
                            MessageBox.Show($"Вопрос \"{questions.Last()}\" не содержит ответа под №{before}.\nВпишите ответ перед следующим запуском.");
                            MainWindow.i = 1;
                            break;
                        }
                        
                        if (buf.Last() == '!')
                        {
                            var rebuild = buf.Substring(0, buf.Length - 1);
                            allAnswers.Add(rebuild);
                            correctAnswers[ansNum]=rebuild;
                            
                        }
                        else
                        {
                            allAnswers.Add(buf);
                        }
                        ansNum++;
                    }
                    else if (ContainsAny(ln, separatorSymbols))
                    {
                        continue;
                    }
                    else
                    {
                        MessageBox.Show("Неверный формат файла! Сброс файла до стандартного шаблона");
                        file.Close();
                        setTemplate(path);
                        System.Windows.Application.Current.Shutdown();
                        break;


                    }


                }
                file.Close();
                

            }
        }

        public void addNew()
        {
            int section = 4;
            if (questions.Any())
            {
                
                if (MainWindow.i <= questions.Count())
                {
                    if (questions.Count() == allAnswers.Count() / 4.0){

                        q.Content = questions[(MainWindow.i - 1)];
                        a1.Content = allAnswers[(MainWindow.i - 1) * section];
                        a2.Content = allAnswers[(MainWindow.i - 1) * section + 1];
                        a3.Content = allAnswers[(MainWindow.i - 1) * section + 2];
                        a4.Content = allAnswers[(MainWindow.i - 1) * section + 3];
                        
                    }
                    else
                    {
                        MessageBox.Show("Несоответсвие между кол-вом вопросов и ответов к ним");
                        System.Diagnostics.Process.GetCurrentProcess().Kill();

                    }

                }
                else
                {
                    var page = new OpScoreP();
                    NavigationService nav = NavigationService.GetNavigationService(this);
                    nav.Navigate(page);
                    MainWindow.i = 1;
                }

            }
            

        }

        private void checkAnswer(object sender, RoutedEventArgs e)
        {
            var senderObject = (Button)sender;
            string answered = (string)senderObject.Content;
            string buttonName = (string)senderObject.Name;
            int buttonNum = Int32.Parse(buttonName[1].ToString());
            
            if (correctAnswers.Any(an => an != " "))
            {
                List<List<string>> partitions = correctAnswers.partition(4);
                if (partitions[MainWindow.i-1].All(an => an == " "))
                {
                        
                    MessageBox.Show("Вопрос не содержит правильных ответов, поэтому вопрос не засчитается");
                    MainWindow.numberQuestions--;

                }
                else
                {
                    if (answered == partitions[MainWindow.i - 1][buttonNum-1])
                    {
                        MainWindow.correct++;
                        MessageBox.Show("Правильно!");
                    }
                    else
                    {
                        MainWindow.incorrect++;
                        MessageBox.Show("Отвен неверен!");
                    }
                }

                MainWindow.i++;

            }
            else
            {
                
                MessageBox.Show("Тест не содержит правильных ответов, исправьте банк ответов!");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            

            addNew();
        }
    }
}
