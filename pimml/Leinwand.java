import java.awt.Color;
import java.awt.Dimension;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.Image;
import java.awt.Rectangle;
import java.awt.Shape;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.swing.JFrame;
import javax.swing.JPanel;

/**
 * Leinwand ist eine Klasse, die einfache Zeichenoperationen auf einer
 * leinwandartigen Zeichenflaeche ermoeglicht. Sie ist eine vereinfachte Version
 * der Klasse Canvas (englisch fuer Leinwand) des JDK und wurde speziell fuer das
 * Projekt "Figuren" geschrieben.
 * 
 * 
 * @author: Bruce Quig
 * @author: Michael Koelling (mik)
 * @author: Axel Schmolitzky
 * 
 * @version: 2006.03.30
 */
public class Leinwand {
    // Hinweis: Die Implementierung dieser Klasse (insbesondere die
    // Verwaltung der Farben und Identitaeten der Figuren) ist etwas
    // komplizierter als notwendig. Dies ist absichtlich so, weil damit
    // die Schnittstellen und Exemplarvariablen der Figuren-Klassen
    // fuer den Lernanspruch dieses Projekts einfacher und klarer
    // sein koennen.

    private static int leinwandBreite = 1000;
    private static int leinwandHoehe = 1000;
    
    private static Leinwand leinwandSingleton;

    /**
     * Fabrikmethode, die eine Referenz auf das einzige Exemplar dieser Klasse
     * zurueckliefert. Wenn es von einer Klasse nur genau ein Exemplar gibt, wird
     * dieses als 'Singleton' bezeichnet.
     */
    public static Leinwand gibLeinwand() {
        if (leinwandSingleton == null) {
            leinwandSingleton = new Leinwand("Informatik EF - BlueJ", leinwandBreite, leinwandHoehe,
                    Color.green);
        }
        leinwandSingleton.setzeSichtbarkeit(true);
        return leinwandSingleton;
    }

    // ----- Exemplarvariablen -----

    private JFrame fenster;

    private Zeichenflaeche zeichenflaeche;

    private Graphics2D graphic;

    private Color hintergrundfarbe;

    private Image leinwandImage;

    private List<Object> figuren;

    private Map<Object, ShapeMitFarbe> figurZuShape;
    
    /**
     * Erzeuge eine Leinwand.
     * 
     * @param titel
     *            Titel, der im Rahmen der Leinwand angezeigt wird
     * @param breite
     *            die gewuenschte Breite der Leinwand
     * @param hoehe
     *            die gewuenschte Hoehe der Leinwand
     * @param grundfarbe
     *            die Hintergrundfarbe der Leinwand
     */
    private Leinwand(String titel, int breite, int hoehe, Color grundfarbe) {
        fenster = new JFrame();
        zeichenflaeche = new Zeichenflaeche();
        fenster.setContentPane(zeichenflaeche);
        fenster.setTitle(titel);
        zeichenflaeche.setPreferredSize(new Dimension(breite, hoehe));
        hintergrundfarbe = grundfarbe;
        fenster.pack();
        figuren = new ArrayList<Object>();
        figurZuShape = new HashMap<Object, ShapeMitFarbe>();
    }

    /**
     * Setze, ob diese Leinwand sichtbar sein soll oder nicht. Wenn die Leinwand
     * sichtbar gemacht wird, wird ihr Fenster in den Vordergrund geholt. Diese
     * Operation kann auch benutzt werden, um ein bereits sichtbares
     * Leinwandfenster in den Vordergrund (vor andere Fenster) zu holen.
     * 
     * @param sichtbar
     *            boolean fuer die gewuenschte Sichtbarkeit: true fuer sichtbar,
     *            false fuer nicht sichtbar.
     */
    public void setzeSichtbarkeit(boolean sichtbar) {
        if (graphic == null) {
            // erstmaliger Aufruf: erzeuge das Bildschirm-Image und fuelle
            // es mit der Hintergrundfarbe
            Dimension size = zeichenflaeche.getSize();
            leinwandImage = zeichenflaeche.createImage(size.width, size.height);
            graphic = (Graphics2D) leinwandImage.getGraphics();
            graphic.setColor(hintergrundfarbe);
            graphic.fillRect(0, 0, size.width, size.height);
            graphic.setColor(Color.black);
        }
        fenster.setVisible(sichtbar);
    }

    /**
     * Zeichne fuer das gegebene Figur-Objekt eine Java-Figur (einen Shape) auf
     * die Leinwand.
     * 
     * @param figur
     *            das Figur-Objekt, fuer das ein Shape gezeichnet werden soll
     * @param farbe
     *            die Farbe der Figur
     * @param shape
     *            ein Objekt der Klasse Shape, das tatsaechlich gezeichnet wird
     */
    public void zeichne(Object figur, String farbe, Shape shape) {
        figuren.remove(figur); // entfernen, falls schon eingetragen
        figuren.add(figur); // am Ende hinzufuegen
        figurZuShape.put(figur, new ShapeMitFarbe(shape, farbe));
        erneutZeichnen();
    }

    /**
     * Entferne die gegebene Figur von der Leinwand.
     * 
     * @param figur
     *            die Figur, deren Shape entfernt werden soll
     */
    public void entferne(Object figur) {
        figuren.remove(figur); // entfernen,falls schon eingetragen
        figurZuShape.remove(figur);
        erneutZeichnen();
    }

    /**
     * Setze die Zeichenfarbe der Leinwand.
     * 
     * @param farbname
     *            der Name der neuen Zeichenfarbe.
     */
    public void setzeZeichenfarbe(String farbname) {
        if (farbname.equals("rot")) {
            graphic.setColor(Color.red);
        } else if (farbname.equals("schwarz")) {
            graphic.setColor(Color.black);
        } else if (farbname.equals("blau")) {
            graphic.setColor(Color.blue);
        } else if (farbname.equals("gelb")) {
            graphic.setColor(Color.yellow);
        } else if (farbname.equals("gruen")) {
            graphic.setColor(Color.green);
        } else if (farbname.equals("lila")) {
            graphic.setColor(Color.magenta);
        } else if (farbname.equals("weiss")) {
            graphic.setColor(Color.white);
        } else {
            graphic.setColor(Color.black);
        }
    }

    /**
     * Warte fuer die angegebenen Millisekunden. Mit dieser Operation wird eine
     * Verzoegerung definiert, die fuer animierte Zeichnungen benutzt werden kann.
     * 
     * @param millisekunden
     *            die zu wartenden Millisekunden
     */
    public void warte(int millisekunden) {
        try {
            Thread.sleep(millisekunden);
        } catch (Exception e) {
            // Exception ignorieren
        }
    }

    /**
     * Zeichne erneut alle Figuren auf der Leinwand.
     */
    private void erneutZeichnen() {
        loeschen();
        for (Object figur : figuren) {
            figurZuShape.get(figur).draw(graphic);
        }
        zeichenflaeche.repaint();
    }

    /**
     * Loesche die gesamte Leinwand.
     */
    private void loeschen() {
        Color original = graphic.getColor();
        graphic.setColor(hintergrundfarbe);
        Dimension size = zeichenflaeche.getSize();
        graphic.fill(new Rectangle(0, 0, size.width, size.height));
        graphic.setColor(original);
    }

    /***************************************************************************
     * Interne Klasse Zeichenflaeche - die Klasse fuer die GUI-Komponente, die
     * tatsaechlich im Leinwand-Fenster angezeigt wird. Diese Klasse definiert
     * ein JPanel mit der zusaetzlichen Moeglichkeit, das auf ihm gezeichnet Image
     * aufzufrischen (erneut zu zeichnen).
     */
    private class Zeichenflaeche extends JPanel {
        private static final long serialVersionUID = 20060330L;

        public void paint(Graphics g) {
            g.drawImage(leinwandImage, 0, 0, null);
        }
    }

    /***************************************************************************
     * Interne Klasse ShapeMitFarbe - Da die Klasse Shape des JDK nicht auch
     * eine Farbe mitverwalten kann, muss mit dieser Klasse die Verknuepfung
     * modelliert werden.
     */
    private class ShapeMitFarbe {
        private Shape shape;

        private String farbe;

        public ShapeMitFarbe(Shape shape, String farbe) {
            this.shape = shape;
            this.farbe = farbe;
        }

        public void draw(Graphics2D graphic) {
            setzeZeichenfarbe(farbe);
            graphic.fill(shape);
        }
    }

}
