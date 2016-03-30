import java.awt.*;
import java.awt.event.*;
import java.io.*;
import java.util.*;
import javax.swing.*;

public class ex1 extends JFrame implements ActionListener{

	JButton btAbrir = new JButton("Abrir");
	JButton btSalvar = new JButton("Salvar");
	JButton btSalvaComo = new JButton("Salvar Como");
	JButton btSair = new JButton("Sair");
	JTextArea txtArea = new JTextArea();
	String nomeArq;

	ex1(){
		super("Editor de texto");
		JPanel painel = new JPanel(new GridLayout(15,1));
		painel.add(btAbrir);
		painel.add(btSalvar);
		painel.add(btSalvaComo);
		painel.add(btSair);
		btAbrir.addActionListener(this);
		btSalvar.addActionListener(this);
		btSalvaComo.addActionListener(this);
		btSair.addActionListener(this);
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

	public void Salvar(String nome){
		FileOutputStream out = null;
		try{   
			out = new FileOutputStream(nome);
			out.write((new String(txtArea.getText())).getBytes());
			out.close();
			JOptionPane.showMessageDialog(null, "Arquivo salvo com sucesso!");
		}  
		catch(IOException ioe){ 
			JOptionPane.showMessageDialog(null, "Erro ao tentar salvar o arquivo. " + ioe);   
		} 
	}

	public void actionPerformed(ActionEvent e){
		if (e.getSource() == btSair){
			System.exit(0);
		}
		else if (e.getSource() == btSalvar){
			if (nomeArq == ""){
				nomeArq = JOptionPane.showInputDialog(null, "Salvar como:");  
			}
			Salvar(nomeArq);
		}
		else if (e.getSource() == btSalvaComo){
			nomeArq = JOptionPane.showInputDialog(null, "Salvar como:");  
			Salvar(nomeArq);
		}
		else if (e.getSource() == btAbrir){
			nomeArq = JOptionPane.showInputDialog(null, "Caminho do arquivo:"); 
			File f = new File(nomeArq);
			FileInputStream in = null;
			try{   
				in = new FileInputStream(f);
				Scanner sin = new Scanner(in);
				txtArea.setText("");
				while (sin.hasNextLine()) {
					txtArea.append(sin.nextLine());
					txtArea.append("\n");
				}
				in.close(); 
			}  
			catch(IOException ioe){ 
				JOptionPane.showMessageDialog(null, "Arquivo não encontrado. ");   
			}
		}
	}

	public static void main(String s[]) {
		new ex1();
	}
}
