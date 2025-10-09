using System.Data;

namespace ClassLibraryExample
{
    //事件参数
    public class CustomEventArgs : EventArgs
    {
        public int num1 { get; set; }
        public int num2 { get; set; }
    }
    public class Publisher
    {
        //创建事件
        public event EventHandler<CustomEventArgs> CustomEvent;
        //触发事件
        public void RaiseEvent(object sender,int a, int b)
        {
            if (this.CustomEvent != null)
            {
                CustomEventArgs e = new CustomEventArgs() { num1 = a, num2 = b };
                this.CustomEvent(this, e);
            }
        }
    }
}
