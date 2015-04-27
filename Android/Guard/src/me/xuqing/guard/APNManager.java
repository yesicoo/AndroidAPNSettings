package me.xuqing.guard;

import java.util.ArrayList;
import java.util.List;
import android.app.Activity;
import android.database.Cursor;
import android.net.Uri;
import android.util.Log;

public class APNManager {

	 public static List<APN> GetAPNList(Activity av){   
	        String tag = "Main.getAPNList()";   
	        Uri uri = Uri.parse("content://telephony/carriers");
	        //current不为空表示可以使用的APN   
	        String  projection[] = {"_id,apn,type,current"};   
	        Cursor cr = av.getContentResolver().query(uri, projection, null, null, null);   
	        List<APN> list = new ArrayList<APN>();   
	           
	        while(cr!=null && cr.moveToNext()){   
	            Log.d(tag, cr.getString(cr.getColumnIndex("_id")) + "  " + cr.getString(cr.getColumnIndex("apn")) + "  " + cr.getString(cr.getColumnIndex("type"))+ "  " + cr.getString(cr.getColumnIndex("current")));   
	            APN a = new APN();   
	            a.id = cr.getString(cr.getColumnIndex("_id"));   
	            a.apn = cr.getString(cr.getColumnIndex("apn"));   
	            a.type = cr.getString(cr.getColumnIndex("type"));   
	            list.add(a);   
	        }   
	        if(cr!=null)   
	        cr.close();   
	        return list;   
	    }
	 
	 public static List<APN> GetAPNList(Cursor cr){   
	        String tag = "Main.getAPNList()";   
	       
	        List<APN> list = new ArrayList<APN>();   
	           
	        while(cr!=null && cr.moveToNext()){   
	            Log.d(tag, cr.getString(cr.getColumnIndex("_id")) + "  " + cr.getString(cr.getColumnIndex("apn")) + "  " + cr.getString(cr.getColumnIndex("type"))+ "  " + cr.getString(cr.getColumnIndex("current")));   
	            APN a = new APN();   
	            a.id = cr.getString(cr.getColumnIndex("_id"));   
	            a.apn = cr.getString(cr.getColumnIndex("apn"));   
	            a.type = cr.getString(cr.getColumnIndex("type"));   
	            list.add(a);   
	        }   
	        if(cr!=null)   
	        cr.close();   
	        return list;   
	    }
}
