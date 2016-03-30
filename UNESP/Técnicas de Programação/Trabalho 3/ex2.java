import java.awt.*;
import java.awt.event.*;
import java.util.*;
import java.lang.*;
import javax.swing.*;

public class ex2 extends JFrame implements ActionListener{
	
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
		soma.addActionListener(this);
		sub.addActionListener(this);
		mult.addActionListener(this);
		div.addActionListener(this);
		add(painel2, BorderLayout.CENTER);
		JPanel painel3 = new JPanel(new FlowLayout(FlowLayout.CENTER));
		c2.setColumns(20);
		painel3.add(c2);
		i.setText(" = ");
		r.setText("             0");
		painel3.add(i);
		painel3.add(r);
		add(painel3, new FlowLayout(FlowLayout.CENTER));
		pack();
		setVisible(true);      
    }
	
	public String Calcula(int tipo){
		try{
			float x1 = Float.parseFloat(c1.getText());  
			float x2 = Float.parseFloat(c2.getText());  
			
			switch(tipo){
				case 1:
					return Float.toString(x1 + x2); 
				case 2:
					return Float.toString(x1 - x2); 
				case 3:
					return Float.toString(x1 * x2);  
				case 4:
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
		if (e.getSource() == soma){
			r.setText(Calcula(1));
		}
		else if (e.getSource() == sub){
			r.setText(Calcula(2));		
		}
		else if (e.getSource() == mult){
			r.setText(Calcula(3));			
		}
		else if (e.getSource() == div){
			r.setText(Calcula(4));				
		}
	}
	
    public static void main(String s[]) {
    	new ex2();
    }
}
