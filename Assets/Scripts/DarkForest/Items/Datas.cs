using System;
using System.Collections.Generic;

[Serializable]
class Datas
{
    public Datas(List<Stars> stars, List<Biaxial_foil> bfs)
    {
        this.stars = stars;
        this.bfs = bfs;
    }
    public List<Stars> stars;
    public List<Biaxial_foil> bfs;
}

