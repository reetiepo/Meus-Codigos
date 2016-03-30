package com.example.leticiarenata;

import android.support.v7.app.ActionBarActivity;
import android.support.v7.app.ActionBar;
import android.support.v4.app.Fragment;
import android.content.Intent;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.Toast;
import android.os.Build;

public class MainActivity extends ActionBarActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        //if (savedInstanceState == null) {
         //   getSupportFragmentManager().beginTransaction()
         //           .add(R.id.container, new PlaceholderFragment())
         //           .commit();
        //}
    }
    
    public void abrirPOPUP(View v){
    	EditText campo1 = (EditText) this.findViewById(R.id.editText1);
    	Spinner sp1 = (Spinner) this.findViewById(R.id.spinner1);
    	Spinner sp2 = (Spinner) this.findViewById(R.id.spinner2);
    	
    	Toast.makeText(this, "Ola " + campo1.getText().toString() + ", sua consulta foi agendada para " 
    	+ sp1.getSelectedItem().toString() + " as " + sp2.getSelectedItem().toString(), 10000000).show();    	
    }
    
    public void novaTela(View v){
    	EditText campo1 = (EditText) this.findViewById(R.id.editText1);
    	EditText campo2 = (EditText) this.findViewById(R.id.editText2);
    	EditText campo3 = (EditText) this.findViewById(R.id.editText3);
    	Spinner sp1 = (Spinner) this.findViewById(R.id.spinner1);
    	Spinner sp2 = (Spinner) this.findViewById(R.id.spinner2);
    	
    	Intent i = new Intent(this, FragmentMain.class);
    	i.putExtra("Nome", campo1.getText().toString());
    	i.putExtra("Telefone", campo2.getText().toString());
    	i.putExtra("Email", campo3.getText().toString());
    	i.putExtra("Dias", sp1.getSelectedItem().toString());
    	i.putExtra("Hora", sp2.getSelectedItem().toString());
    	
    	startActivity(i);
    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();
        if (id == R.id.action_settings) {
            return true;
        }
        return super.onOptionsItemSelected(item);
    }

    /**
     * A placeholder fragment containing a simple view.
     */
    public static class PlaceholderFragment extends Fragment {

        public PlaceholderFragment() {
        }

        @Override
        public View onCreateView(LayoutInflater inflater, ViewGroup container,
                Bundle savedInstanceState) {
            View rootView = inflater.inflate(R.layout.fragment_main, container, false);
            return rootView;
        }
    }

}
