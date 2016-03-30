import java.awt.*;
import javax.swing.*;

public class ex1 extends JFrame {
    
	JButton btAbrir = new JButton("Abrir");
	JButton btSalvar = new JButton("Salvar");
	JButton btSalvaComo = new JButton("Salvar Como");
	JButton btSair = new JButton("Sair");
	JTextArea txtArea = new JTextArea();
    
    ex1(){
    	super("Editor de texto");
    	JPanel painel = new JPanel(new GridLayout(15,1));
    	painel.add(btAbrir);
    	painel.add(btSalvar);
    	painel.add(btSalvaComo);
    	painel.add(btSair);
    	add(painel, BorderLayout.WEST);
    	JScrollPane roll = new JScrollPane(txtArea);
    	add(roll, BorderLayout.CENTER);
    	txtArea.setColumns(50);
    	txtArea.setRows(20);
    	String s;
    	s = "Digite texto nessa área\n            	             com \n                           " +
    			"                        várias\n                                                               linhas.";
    	txtArea.setText(s);
    	add(txtArea, BorderLayout.EAST);
    	pack();
    	setVisible(true);      
    }
    
    public static void main(String s[]) {
    		new ex1();
    	}
}
