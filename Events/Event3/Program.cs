using System;

namespace Event3
{
    public delegate void KeyPressEventDelegate();// create event. not delegate because event! 
    public class KeyBoardMaster
    {
        public event KeyPressEventDelegate wKeyPressEvent = null;
        public event KeyPressEventDelegate sKeyPressEvent = null;

       public void WKeyPressEvent()
        {
            if(wKeyPressEvent != null)
            {
                wKeyPressEvent.Invoke();
            }
        }

        public void SKeyPressEvent()
        {
            if (sKeyPressEvent != null)
            {
                sKeyPressEvent.Invoke();
            }
        }
    }
    class Program
    {
        static private void buttonW_Click()
        {
            Console.WriteLine("Event W");
        }
        static private void buttonS_Click()
        {
            Console.WriteLine("Event S");
        }

        static void Main(string[] args)
        {
            KeyBoardMaster km = new KeyBoardMaster();

            km.wKeyPressEvent += buttonW_Click;
            km.sKeyPressEvent += buttonS_Click;

            ConsoleKey pressedKey;

            while (true)
            {
                pressedKey = Console.ReadKey().Key;
                switch(pressedKey)
                {
                    case ConsoleKey.W:
                        km.WKeyPressEvent();
                        //km.wKeyPressEvent -= buttonW_Click;
                        break;
                    case ConsoleKey.S:
                        km.SKeyPressEvent();
                        break;
                }
            }
        }
    }
}

