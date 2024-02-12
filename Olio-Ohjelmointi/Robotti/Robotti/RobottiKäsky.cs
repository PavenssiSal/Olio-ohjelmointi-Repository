using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robotti
{
    //Abstractin luokan tarkotus on; että se kertoo millaisia tietunlaiset oliot ovat
    //Siitä itsestään ei voi tehdä oliota: se on vain abstracti idea
    public abstract class RobottiKäsky
    {
        //Tämän pitää olla myös abstract jos luokka on abstract
        //Saa parametriksi Robotin, jota käsky koskee
        public abstract void Suorita(Robotti toimija);
    }
}
