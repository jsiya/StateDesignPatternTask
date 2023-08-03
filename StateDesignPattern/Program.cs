namespace StateDesignPattern
{
    public interface IState //action ve neticesi ucun method saxlayir
    {
        public void DoAction(Context context);
        public string GetLightState();
    }

    public class TurnLightOn : IState //isiq yanilidirsa
    {
        public string LightIs { get; set; } = "ON";
        public void DoAction(Context context)
        {
            Console.WriteLine("The Light is ON");
            context.State = this;
        }

        public string GetLightState()
        {
            return LightIs;
        }
    }

    public class TurnLightOff : IState // isiq sonuludurse
    {
        public string LightIs { get; set; } = "OFF";
        public void DoAction(Context context)
        {
            Console.WriteLine("The Light is OFF");
            context.State = this;
        }

        public string GetLightState()
        {
            return LightIs;
        }
    }
    
    public class Context  //state deyisdikde deyisir davranisi deyisir
    {
        public IState State { get; set; }
        public Context()
        {
            State = null;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            IState turnLightOn = new TurnLightOn();
            turnLightOn.DoAction(context);
            //isigi yandirdiqda
            Console.WriteLine($"Context= {context.State.GetLightState()}");

            IState turnLightOff = new TurnLightOff();
            turnLightOff.DoAction(context);
            //isigi sondurdukde
            Console.WriteLine($"Context= {context.State.GetLightState()}");
        }
    }
}