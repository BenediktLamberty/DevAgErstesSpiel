public class Baum 
{
 
    private Quadrat stamm;
    private Kreis krone;
    private Kreis apfel;
     
    public Baum(int x, int y)
    {
        stamm = new Quadrat();
        stamm.bewegeZuPosition(x,y);
        stamm.farbeAendern("schwarz");
        krone = new Kreis();
        krone.bewegeZuPosition(x-10,y-40);
        krone.groesseAendern(50);
        krone.farbeAendern("gruen");
        apfel = new Kreis();
        apfel.bewegeZuPosition(x,y);
        apfel.groesseAendern(10); 
        apfel.farbeAendern("gelb");
        stamm.sichtbarMachen();
        krone.sichtbarMachen();
        apfel.sichtbarMachen();
    }
    
    public void sichtbarMachen()
    {
        stamm.sichtbarMachen();
        krone.sichtbarMachen();
        apfel.sichtbarMachen();
    }
    public void unsichtbarMachen()
    {
        stamm.unsichtbarMachen();
        krone.unsichtbarMachen();
        apfel.unsichtbarMachen();
    }
    public void langsamHorizontalBewegen(int distanz)
    {
        stamm.langsamHorizontalBewegen(distanz);
        krone.langsamHorizontalBewegen(distanz);
        apfel.langsamHorizontalBewegen(distanz);
    }
    public void langsamVertikalBewegen(int distanz)
    {
        stamm.langsamVertikalBewegen(distanz);
        krone.langsamVertikalBewegen(distanz);
        apfel.langsamVertikalBewegen(distanz);
    }
    public void herbst(){
        krone.farbeAendern("rot");
    }
    public void winter(){
        krone.farbeAendern("gra");
    }
}