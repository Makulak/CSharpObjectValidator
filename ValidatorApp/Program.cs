using System.Collections.Generic;
using System.Linq;

namespace ValidatorApp
{
    public class Cl
    {
        public string ValOne { get; set; }
        public bool ValTwo { get; set; }
        public int ValThree { get; set; }
        public IEnumerable<double> ValFour { get; set; }
        public Cll[] ValFive { get; set; }
    }

    public class Cll
    {
        public int ValChildrenOne { get; set; }
        public string ValChidlrenTwo { get; set; }
    }

    public class Test
    {
        public void Check()
        {
            var cl = new Cl();
            cl.ValOne = "incorrectValue";
            cl.ValTwo = true;
            cl.ValThree = 666;
            cl.ValFour = new List<double>();
            cl.ValFive = new Cll[] { new Cll { ValChildrenOne = 1, ValChidlrenTwo = "correctValue" },
                                     new Cll { ValChildrenOne = 2, ValChidlrenTwo = "incorrectValue" }};

            Validator<Cl> validator = new ValidatorBuilder<Cl>()
                .AddCheck(x => x.ValTwo == true, "ValTwo should be true1")
                .AddCheck(x => x.ValOne == "correctValue", "ValOne should be 'CorrectValue'")
                .AddCheck(x => x.ValThree == 30, "ValThree should be 30")
                .AddCheck(x => x.ValFour.Count() == 0, "Length of ValFour should be zero")
                .AddCheck(x => x.ValFive != null, "ValVise should not be null")
                .AddCheck(x => x.ValFive.All(y => y.ValChidlrenTwo == "correctValue"), "All ValChildrenTwo should be 'correctValue'")
                .AddCheck(x => x.ValFive.All(y => y.ValChildrenOne == 2), "All ValChildrenOne should be equal to two")
                .Create();

            var isValid = validator.IsValid(cl);
            var firstMessages = validator.Validate(cl);
            var allMessages = validator.ValidateA(cl);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var t = new Test();
            t.Check();
        }
    }
}
