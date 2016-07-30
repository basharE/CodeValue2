using System;

namespace Rationals
{
    class Program
    {
        static void Main()
        {
            Rational r1 = new Rational(2,3);
            Rational r2 = new Rational(4,6);
            Rational r3 = new Rational(6, 4);
            Rational r4 = new Rational(4, 12);
            Rational r5 = new Rational(4, 3);
            Rational r6 = new Rational(2, 4);
            Rational r7 = new Rational(3, 4);


            Console.WriteLine(r1 + r7);
            Console.WriteLine(r1 - r7);
            Console.WriteLine(r1 * r7);
            Console.WriteLine(r1 / r7);

            //Rational r7 = new Rational(2);
            //Rational re = r7.Mul(r4);
            //Console.WriteLine(re.ToString());
            //re.Reduce();
            //Console.WriteLine(re.ToString());
            //re = re.Add(r5);
            //Console.WriteLine(re.ToString());
            //re.Reduce();
            //Console.WriteLine(re.ToString());



            //r6.Reduce();
            //r3 = r3.Mul(r4);
            //Console.WriteLine(r3.ToString());
            //r3.Reduce();
            //Console.WriteLine(r3.ToString());

            //Console.WriteLine(r6.ToString());
            //Console.WriteLine(r1.Equals(r2));
            //Console.WriteLine(r1.ToString());
            //Console.WriteLine(r2.ToString());
            //Console.WriteLine(r3.ToString());
            //Console.WriteLine(r4.ToString());
            //r1 = r1.Add(r2);
            //Console.WriteLine(" res "+r1);
            //r1.Reduce();
            //Console.WriteLine(r1);
            //Console.WriteLine(r1.Equals(r2));

        }
    }


    public struct Rational
    {
        private int _numerator;
        private int _denominator;
        //a
        public Rational(int nu, int deno)
        {
            _numerator = nu;
            _denominator = deno;
        }
        //b
        public Rational(int nu)
        {
            _numerator = nu;
            _denominator = 1;
        }
        //c
        public int Numerator
        {
            get { return _numerator; }
            private set { _numerator = value; }
        }

        public int Denominator
        {
            get { return _denominator; }
            private set { _denominator = value; }
        }
        //d
        public double Value
        {
            get { return _numerator/_denominator; }
        }
        //e
        public Rational Add(Rational r1)
        {
            var num = r1.Numerator*this.Denominator + r1.Denominator*this.Numerator;
            var den = r1.Denominator*this.Denominator;
            var res = new Rational(num, den);
            res.Reduce();
            return res;
        }
        //f
        public Rational Mul(Rational r1)
        {
            var num = r1.Numerator * this.Numerator;
            var den = r1.Denominator * this.Denominator;
            var res = new Rational(num, den);
            res.Reduce();
            return res;
        }
        //g
        public void Reduce()
        {
            int x = 2;
            if (_numerator == _denominator)
            {
                _denominator = 1;
                _numerator = 1;
            }
            else
            {
                while (x <= _denominator && x <= _numerator)
                {
                    if (_denominator%x == 0 && _numerator%x == 0)
                    {
                        _denominator /=x ;
                        _numerator /=x ;
                    }
                    else
                    {
                        x++;
                    }
                }
            }
        }
        //h
        public override string ToString()
        {        
            return Numerator + "/" + Denominator;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Rational o = (Rational) obj;
            Rational t = (Rational) this;
            o.Reduce();
            t.Reduce();
            return (o.Denominator==t.Denominator)&&(o.Numerator==t.Numerator);
        }

        public static Rational operator +(Rational r1, Rational r2) =>
        new Rational(r1._numerator * r2._denominator + r2._numerator * r1._denominator , r1._denominator * r2._denominator);

        public static Rational operator -(Rational r1, Rational r2) =>
        new Rational(r1._numerator * r2._denominator - r2._numerator * r1._denominator, r1._denominator * r2._denominator);

        public static Rational operator *(Rational r1, Rational r2) =>
        new Rational(r1._numerator * r2._numerator, r1._denominator * r2._denominator);

        public static Rational operator /(Rational r1, Rational r2) =>
        new Rational(r1._numerator * r2._denominator, r1._denominator * r2._numerator);

        public static implicit operator double(Rational r)
        {
            return (double)r._numerator/r._denominator;
        }

        public static implicit operator Rational(int n)
        {
            return new Rational(n,1);
        }
    }
}
