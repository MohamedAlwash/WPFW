namespace ConsoleGame
{
    class Muntje : Plaatsbaar
    {
        private bool knipper;
        public override char Symbol
        {
            get
            {
                if (knipper)
                    return 'O';
                else
                    return ' ';
            }
        }
        public override void Teken()
        {
            base.Teken();
            knipper = !knipper;
        }
    }
}