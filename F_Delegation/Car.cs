using System;

namespace F_Delegation
{
    public class Car
    {
        int speed = 0;
        public event EventHandler<CarArgs> TooFastDriving;//Action - тольko на приём параметров
        //если хотим так же что-то вернуть, используем делегат Func
        //public delegate void TooFast(int speed); Мы можем и не создавать свой делегат, а использовать готовые
       // private TooFast tooFast;
        public void Start()
        {
            speed = 10;
        }
        public void Accelerate()
        {
            speed += 10;
            if (speed > 80)
            {
                if(TooFastDriving!=null)
                TooFastDriving(this,new CarArgs(speed) );
            }
                

        }

        public void Stop()
        {
            speed = 0;
        }
    /*    public void RegisterOnTooFast(TooFast tooFast)
        {
            ToFastDriving += tooFast;
        }
        public void UnregisterOnTooFast(TooFast tooFast)
        {
            ToFastDriving -= tooFast;
        }
    */
    }
}
