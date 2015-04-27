package me.xuqing.guard;

import java.io.BufferedReader;
import java.io.DataOutputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;

import android.os.SystemClock;
import android.view.MotionEvent;
import android.view.View;

public class FoolHand {

	/**
	 * 执行shell命令
	 * 
	 * @param cmd
	 */
	public static void execShellCmd(String cmd) {

		try {
			// 申请获取root权限
			Process process = Runtime.getRuntime().exec("su");
			OutputStream outputStream = process.getOutputStream();
			DataOutputStream dataOutputStream = new DataOutputStream(
					outputStream);
			dataOutputStream.writeBytes(cmd);
			dataOutputStream.flush();
			dataOutputStream.close();
			outputStream.close();
		} catch (Throwable t) {
			t.printStackTrace();
		}
	}

	public static String DoPing(String url) {

		try {
			System.out.println("FoolHand.DoPing()");
			StringBuffer sb=new  StringBuffer();
			Process process = Runtime.getRuntime().exec("/system/bin/ping -c 4 " + url);
			process.waitFor(); 
			String line = null;
			BufferedReader reader = new BufferedReader(new InputStreamReader(process.getInputStream()));
			while((line = reader.readLine()) != null)
			{
				sb.append(line).append("\r\n");
			}
			reader.close();
			System.out.println("FoolHand.DoPing() Over");
			return sb.toString();
		} catch (Throwable t) {
			t.printStackTrace();
			return "Error";
		}
	}
}
