
/**
 * Beschreiben Sie hier die Klasse Pimml.
 * 
 * @author (Ihr Name) 
 * @version (eine Versionsnummer oder ein Datum)
 */
public class pimml extends Quadrat
{
    // Instanzvariablen - ersetzen Sie das folgende Beispiel mit Ihren Variablen
    private int x;
    private int y;
    private Kreis RechtesEi;
    private Kreis LinkesEi;
    private Kreis Spitze;
    private Quadrat pimml;
    int Schaukler;
    /**
     * Konstruktor für Objekte der Klasse Pimml
     */
    public pimml()
    {
        pimml = new Quadrat();
        pimml.bewegeZuPosition(150,100);
        pimml.farbeAendern("schwarz");
        pimml.sichtbarMachen();
        
        pimml = new Quadrat();
        pimml.bewegeZuPosition(150,125);
        pimml.farbeAendern("schwarz");
        pimml.sichtbarMachen();
        
        pimml = new Quadrat();
        pimml.bewegeZuPosition(150,150);
        pimml.farbeAendern("schwarz");
        pimml.sichtbarMachen();
        
        Spitze = new Kreis();
        Spitze.bewegeZuPosition(147,77);
        Spitze.groesseAendern(35);
        Spitze.farbeAendern("schwarz");
        Spitze.sichtbarMachen();
        
        RechtesEi = new Kreis();
        RechtesEi.bewegeZuPosition(147,160);
        RechtesEi.groesseAendern(35);
        RechtesEi.farbeAendern("schwarz");
        RechtesEi.sichtbarMachen();
        
        RechtesEi = new Kreis();
        RechtesEi.bewegeZuPosition(160,165);
        RechtesEi.groesseAendern(40);
        RechtesEi.farbeAendern("schwarz");
        RechtesEi.sichtbarMachen();

        LinkesEi = new Kreis();
        LinkesEi.bewegeZuPosition(130,165);
        LinkesEi.groesseAendern(40);
        LinkesEi.farbeAendern("schwarz");
        LinkesEi.sichtbarMachen();
    }
    public void RechtesEiSchaukeln(){
        RechtesEi.langsamVertikalBewegen(-10);
        RechtesEi.langsamHorizontalBewegen(10);
        RechtesEi.langsamVertikalBewegen(10);
        RechtesEi.langsamHorizontalBewegen(-10);
    }
    public void LinkesEiSchaukeln(){
        LinkesEi.langsamVertikalBewegen(-10);
        LinkesEi.langsamHorizontalBewegen(-10);
        LinkesEi.langsamVertikalBewegen(10);
        LinkesEi.langsamHorizontalBewegen(10);
    }
    
    public void EierSchaukeln(){
        Schaukler = 0;
        while(Schaukler < 10){
            LinkesEi.langsamVertikalBewegen(-5);
            RechtesEi.langsamVertikalBewegen(-5);
            LinkesEi.langsamHorizontalBewegen(-5);
            RechtesEi.langsamHorizontalBewegen(5);
            LinkesEi.langsamVertikalBewegen(5);
            RechtesEi.langsamVertikalBewegen(5);
            LinkesEi.langsamHorizontalBewegen(5);
            RechtesEi.langsamHorizontalBewegen(-5);
            Schaukler ++;
        }
    }
    public void Wixxn(){
        Schaukler = 0;
        while(Schaukler < 10){
        Spitze.langsamVertikalBewegen(-4);
        Spitze.langsamVertikalBewegen(4);
        Schaukler ++;
    }
    pimml = new Quadrat();
        pimml.bewegeZuPosition(150,48);
        pimml.farbeAendern("weiss");
        pimml.sichtbarMachen();
    pimml = new Quadrat();
        pimml.bewegeZuPosition(155,38);
        pimml.farbeAendern("weiss");
        pimml.sichtbarMachen();
    pimml = new Quadrat();
        pimml.bewegeZuPosition(145,38);
        pimml.farbeAendern("weiss");
        pimml.sichtbarMachen();
    pimml = new Quadrat();
        pimml.bewegeZuPosition(140,28);
        pimml.farbeAendern("weiss");
        pimml.sichtbarMachen();
    pimml = new Quadrat();
        pimml.bewegeZuPosition(160,28);
        pimml.farbeAendern("weiss");
        pimml.sichtbarMachen();
    pimml = new Quadrat();
        pimml.bewegeZuPosition(155,18);
        pimml.farbeAendern("weiss");
        pimml.sichtbarMachen();
    pimml = new Quadrat();
        pimml.bewegeZuPosition(145,18);
        pimml.farbeAendern("weiss");
        pimml.sichtbarMachen();
    pimml = new Quadrat();
        pimml.bewegeZuPosition(150,8);
        pimml.farbeAendern("weiss");
        pimml.sichtbarMachen();
    }
}
