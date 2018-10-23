using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAnalysis
{
    class Blackbox
    {
        public string controller_model;
        public int run_time;
        public string software_version;
        public int run_origin;
        public decimal gps_latitude;
        public List<string> details_headers;
        public string uuid;
        public List<List<object>> details_data;
        public string controller_application;
        public string product_name;
        public string version;
        public string hardware_version;
        public bool gps_available;
        public string date;
        public string product_id;
        public decimal gps_longitude;
        public string user;
        public string serial_number;
        public int total_run_time;
        public int product_style;
        public string jump;
        public int crash;

        public List<int> time = new List<int>();
        public List<int> battery_level = new List<int>();
        public List<decimal> controller_gps_longitude = new List<decimal>();
        public List<decimal> controller_gps_latitude = new List<decimal>();
        public List<int> flying_state = new List<int>();
        public List<int> using_mode = new List<int>();
        public List<int> alert_state = new List<int>();
        public List<int> wifi_signal = new List<int>();
        public List<bool> magneto_calibrated = new List<bool>();
        public List<bool> product_gps_available = new List<bool>();
        public List<decimal> product_gps_longitude = new List<decimal>();
        public List<decimal> product_gps_latitude = new List<decimal>();
        public List<int> product_gps_altitude = new List<int>();
        public List<int> product_gps_sv_number = new List<int>();
        public List<int> product_position_quality = new List<int>();
        public List<int> product_link_quality = new List<int>();
        public List<int> streaming_quality = new List<int>();
        public List<int> piloting_quality = new List<int>();
        public List<decimal> speed_vx = new List<decimal>();
        public List<decimal> speed_vy = new List<decimal>();
        public List<decimal> speed_vz = new List<decimal>();
        public List<decimal> angle_phi = new List<decimal>();
        public List<decimal> angle_theta = new List<decimal>();
        public List<int> camera_pan = new List<int>();
        public List<int> camera_tilt = new List<int>();
        public List<decimal> angle_psi = new List<decimal>();
        public List<int> altitude = new List<int>();
        public List<decimal> speed = new List<decimal>();
        public List<decimal> SpeedVsTheta = new List<decimal>();

        public void SVT()
        {
            for (int i = 0; i < speed.Count; i++)
            {
                SpeedVsTheta.Add(speed[i] - angle_theta[i]);
            }
        }

        public void ConvertToNatives()
        {
            for (int i = 0; i < details_data.Count; i++)
            {
                time.Add((int)details_data[i][0]);
                battery_level.Add((int)details_data[i][1]); 
                controller_gps_longitude.Add((int)details_data[i][2]);
                controller_gps_latitude.Add((int)details_data[i][3]);
                flying_state.Add((int)details_data[i][4]);
                using_mode.Add((int)details_data[i][5]);
                alert_state.Add((int)details_data[i][6]);
                wifi_signal.Add((int)details_data[i][7]);
                magneto_calibrated.Add((bool)details_data[i][8]);
                product_gps_available.Add((bool)details_data[i][9]);
                product_gps_longitude.Add(Convert.ToDecimal(details_data[i][10]));
                product_gps_latitude.Add(Convert.ToDecimal(details_data[i][11]));
                product_gps_altitude.Add((int)details_data[i][12]);
                product_gps_sv_number.Add((int)details_data[i][13]);
                product_position_quality.Add((int)details_data[i][14]);
                product_link_quality.Add((int)details_data[i][15]);
                streaming_quality.Add((int)details_data[i][16]);
                piloting_quality.Add((int)details_data[i][17]);
                speed_vx.Add(Convert.ToDecimal(details_data[i][18]));
                speed_vy.Add(Convert.ToDecimal(details_data[i][19]));
                speed_vz.Add(Convert.ToDecimal(details_data[i][20]));
                angle_phi.Add(Convert.ToDecimal(details_data[i][21]));
                angle_theta.Add(Convert.ToDecimal(details_data[i][22]));
                camera_pan.Add((int)details_data[i][23]);
                camera_tilt.Add((int)details_data[i][24]);
                angle_psi.Add(Convert.ToDecimal(details_data[i][25]));
                altitude.Add((int)details_data[i][26]);
                speed.Add(Convert.ToDecimal(details_data[i][27]));
            }
        }
    }
}

