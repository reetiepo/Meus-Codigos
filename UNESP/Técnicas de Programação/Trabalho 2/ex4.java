import java.awt.*;

import javax.swing.*;

public class ex4 extends JFrame{
		
		JTextField c1 = new JTextField();
		JTextField c2 = new JTextField();
		String[] ops = {"Soma", "Subtrai", "Divide", "Multiplica"};
		JComboBox op = new JComboBox(ops);		
		JButton calc = new JButton("Calcular");
		JLabel i = new JLabel();
		JLabel r = new JLabel();
		
		
		ex4(){
	    	super("Calculadora");
	    	setLayout(new GridLayout(2,1));
	    	JPanel painel1 = new JPanel(new FlowLayout(FlowLayout.CENTER));
	    	c1.setColumns(20);
	    	painel1.add(c1);
	    	add(painel1, BorderLayout.EAST);
	    	painel1.add(op);
	    	c2.setColumns(20);
	    	painel1.add(c2);
	    	i.setText(" = ");
	    	r.setText(" 0 ");
	    	painel1.add(i);
	    	painel1.add(r);
	    	JPanel painel4 = new JPanel(new FlowLayout(FlowLayout.CENTER));
	    	painel4.add(calc);
	    	add(painel4, BorderLayout.SOUTH);
	    	pack();
	    	setVisible(true);      
	    }
	    
	    public static void main(String s[]) {
	    		new ex4();
	    	}

}
