import java.awt.*;
import javax.swing.*;


public class ex2 extends JFrame {
	
	JTextField c1 = new JTextField();
	JTextField c2 = new JTextField();
	JButton soma = new JButton("Soma");
	JButton sub = new JButton("Subtrai");
	JButton mult = new JButton("Multiplica");
	JButton div = new JButton("Divide");
	JLabel i = new JLabel();
	JLabel r = new JLabel();
	
	
	ex2(){
    	super("Calculadora");
    	setLayout(new FlowLayout(FlowLayout.CENTER));
    	JPanel painel1 = new JPanel(new FlowLayout(FlowLayout.CENTER));
    	c1.setColumns(20);
    	painel1.add(c1);
    	add(painel1, BorderLayout.WEST);
    	JPanel painel2 = new JPanel(new GridLayout(4,1));
    	painel2.add(soma);
    	painel2.add(sub);
    	painel2.add(mult);
    	painel2.add(div); 
    	add(painel2, BorderLayout.CENTER);
    	JPanel painel3 = new JPanel(new FlowLayout(FlowLayout.CENTER));
    	c2.setColumns(20);
    	painel3.add(c2);
    	i.setText(" = ");
    	r.setText(" 0 ");
    	painel3.add(i);
    	painel3.add(r);
    	add(painel3, new FlowLayout(FlowLayout.CENTER));
    	pack();
    	setVisible(true);      
    }
    
    public static void main(String s[]) {
    		new ex2();
    	}
    
}
