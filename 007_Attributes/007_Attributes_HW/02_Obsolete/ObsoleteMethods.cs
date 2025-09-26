namespace Obsolete
{
    internal class ObsoleteMethods
    {
        [Obsolete("The method is deprecated but you still can use it")]
        public void OldMethod()
        {
            Console.WriteLine("OldMethod calling");
        }

        [Obsolete("The method is no longer supported. You can't use it", true)]
        public void VeryOldMethod()
        {
            Console.WriteLine("VeryOldMethod calling");
        }
    }
}
