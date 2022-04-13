namespace DamageNS
{
    public class Damage
    {
        private double Magical;
        private double Physical;
        private double True;
        //private Effect Buff;

        public Damage(double Physical, double Magical, double True/*, Effect Buff*/){
            this.Physical = Physical;
            this.Magical = Magical;
            this.True = True;
            // this.Buff = Buff;
        }

        public double getPhysical(){return this.Physical;}
        public double getMagical(){return this.Magical;}
        public double getTrue(){return this.True;}
        //public Effect getEffect(){return this.Buff;}
    }
}