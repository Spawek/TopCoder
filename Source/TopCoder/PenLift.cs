using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TopCoder
{
    /*
     * start: 22:15
     * koniec: 23:15 (ale tylko rozkminione jak zrobić graf z tego + poczytanka o cyklach eulera)
     * 
     * Rozkmina co z tym zrobić:
     *      Struktura danych:
     *          osobno dla x i y:
     *              mapa<lista<para<int,int>>>
     *              mapka list linii w danej linii x i y
     *      
     *      Wprowadzić dane do map
     *      Połączyć nachodzące się linię
     *      Znaleźć końce linii i punkty przecięć i zbudować z nich graf
     *      
     *      Na grafie rozdzielić problem na podproblemy jeśli to możliwe (na spójne grafy)
     *      
     *      Znaleźć w każdym grafie liczbę wierzchołków z nieparzystą liczbą krawędzi 
     *      (http://pl.wikipedia.org/wiki/Graf_eulerowski#Graf_nieskierowany)
     *      Jeśli trzeba przejechać 1 raz po tym grafie to może być ścieżka Eulera
     *      Jeśli więcej to trzeba cykl
     *      
     *      Doliczyć kary za miejsca, w których się nie dało
     *      
     *      Zsumować kary + miejsca do których trzeba przeskoczyć 
     *      (i nie spierdolić w tym prostym miejscu - trzeba to jeszcze rozpisać)
     *      
     *      ...
     *      odjąć od wyniku 1 (bo to jest ile razy trzeba podnieść długopis)
     *      ...
     *      PROFIT ;)
     */
    class PenLift
    {
    }
}
