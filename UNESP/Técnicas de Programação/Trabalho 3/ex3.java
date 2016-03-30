import java.awt.*;
import java.awt.event.*;
import java.util.*;
import java.lang.*;
import javax.swing.*;

public class ex3 extends JFrame implements ActionListener{
		
	JTextField c1 = new JTextField();
	JTextField c2 = new JTextField();
	String[] ops = {"Soma", "Subtrai", "Divide", "Multiplica"};
	JComboBox op = new JComboBox(ops);		
	JButton calc = new JButton("Calcular");
	JLabel i = new JLabel();
	JLabel r = new JLabel();

	ex3(){
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
		r.setText("             0");
		painel1.add(i);
		painel1.add(r);
		JPanel painel4 = new JPanel(new BorderLayout());
		painel4.add(calc);
		calc.addActionListener(this);
		add(painel4, BorderLayout.SOUTH);
		pack();
		setVisible(true);      
	}
	
	public String Calcula(String tipo){
		try{
			float x1 = Float.parseFloat(c1.getText());  
			float x2 = Float.parseFloat(c2.getText());  
			
			switch(tipo){
				case "Soma":
					return Float.toString(x1 + x2); 
				case "Subtrai":
					return Float.toString(x1 - x2); 
				case "Multiplica":
					return Float.toString(x1 * x2);  
				case "Divide":
					if (x2 != 0)
						return Float.toString(x1 / x2); 
					JOptionPane.showMessageDialog(null, "Impossível dividir por 0."); 
					return("             0");
			}
		}
		catch(Exception ex){
			JOptionPane.showMessageDialog(null, "Erro ao tentar calcular. Entrada de dados incorreta, insira apenas números!");  
		}
		return("             0");
	}
	
	public void actionPerformed(ActionEvent e){
		r.setText(Calcula(op.getSelectedItem().toString()));
	}
	
	public static void main(String s[]) {
		new ex3();
	}
}
