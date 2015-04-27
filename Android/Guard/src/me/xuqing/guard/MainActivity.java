package me.xuqing.guard;

import java.io.IOException;
import java.net.SocketException;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import org.apache.commons.net.telnet.TelnetClient;

import me.xuqing.CallBack;
import me.xuqing.SCServer;
import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.net.Uri;
import android.net.wifi.WifiInfo;
import android.net.wifi.WifiManager;
import android.os.Bundle;
import android.os.SystemClock;
import android.provider.Settings;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Toast;

public class MainActivity extends Activity {

	String WalnIP;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);

		WifiManager wifiManager = (WifiManager) getSystemService(Context.WIFI_SERVICE);
		// 判断wifi是否开启
		if (wifiManager.isWifiEnabled()) {
			WifiInfo wifiInfo = wifiManager.getConnectionInfo();
			int ipAddress = wifiInfo.getIpAddress();
			WalnIP = intToIp(ipAddress);
		}

	}

	private String intToIp(int i) {
		return (i & 0xFF) + "." + ((i >> 8) & 0xFF) + "." + ((i >> 16) & 0xFF)
				+ "." + (i >> 24 & 0xFF);
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

	public void btnStart(View view) {

		final View thisView = view;
		Log.d("Start", "start " + WalnIP + ":" + 57641);
		final SCServer sc = new SCServer(57641);

		sc.RegistCallBack("OpenApnPage", new CallBack() {
			@Override
			public void execute(Integer clientID, String callBackComm,
					Map<String, String> msgDatas) {
				Intent intent = new Intent(Settings.ACTION_APN_SETTINGS);
				startActivity(intent);
				msgDatas.clear();
				msgDatas.put("Result", "OK");
				sc.Send(clientID, callBackComm, msgDatas);
			}
		});
		sc.RegistCallBack("AddApn", new CallBack() {
			@Override
			public void execute(Integer clientID, String callBackComm,
					Map<String, String> msgDatas) {
				Intent intent = new Intent(Settings.ACTION_APN_SETTINGS);
				startActivity(intent);
				SystemClock.sleep(1000);
				for (int i = 0; i < msgDatas.values().size(); i++) {
					String strDo = msgDatas.get(i + "");
					FoolHand.execShellCmd(strDo);
					Log.d("strDo", strDo);
					SystemClock.sleep(700);
				}
				msgDatas.clear();
				msgDatas.put("Result", "OK");
				sc.Send(clientID, callBackComm, msgDatas);
			}
		});
		sc.RegistCallBack("DoTelnet", new CallBack() {
			@Override
			public void execute(Integer clientID, String callBackComm,
					Map<String, String> msgDatas) {
				String ip = msgDatas.get("IP");
				String port = msgDatas.get("Port");
				TelnetClient tc = new TelnetClient();
				
				msgDatas.clear();
				msgDatas.put("Result", "NOK");
				try {
					tc.setConnectTimeout(3000);
					tc.connect(ip, Integer.parseInt(port));
					msgDatas.put("Result", "OK");
					tc.disconnect();
				} catch (NumberFormatException e) {
					
				} catch (SocketException e) {
					
				} catch (IOException e) {
				
				}
				sc.Send(clientID, callBackComm, msgDatas);
			}
		});

		sc.RegistCallBack("DoPing", new CallBack() {
			@Override
			public void execute(Integer clientID, String callBackComm,
					Map<String, String> msgDatas) {
				String url = msgDatas.get("URL");
				String PingResult = FoolHand.DoPing(url);
				msgDatas.clear();
				msgDatas.put("Result", "OK");
				msgDatas.put("PingResult", PingResult);
				sc.Send(clientID, callBackComm, msgDatas);
			}
		});
		sc.RegistCallBack("SetNetMode", new CallBack() {
			@Override
			public void execute(Integer clientID, String callBackComm,
					Map<String, String> msgDatas) {
				Intent intent = new Intent(Settings.ACTION_WIRELESS_SETTINGS);
				startActivity(intent);

				for (int i = 0; i < msgDatas.values().size(); i++) {
					String strDo = msgDatas.get(i + "");
					FoolHand.execShellCmd(strDo);
					Log.d("strDo", strDo);
					SystemClock.sleep(1000);
				}
				msgDatas.clear();
				msgDatas.put("Result", "OK");
				sc.Send(clientID, callBackComm, msgDatas);
			}
		});
		new Thread(sc).start();
		Toast.makeText(this, "start " + WalnIP + ":" + 57641+",Run In Background !",
				Toast.LENGTH_SHORT).show();
		
		FoolHand.execShellCmd("input keyevent 3");
	}

}
