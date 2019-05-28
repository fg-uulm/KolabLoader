namespace KolabLoader
{
    class SteamConfigContainer
    {
    }


    public class Rootobject
    {
        public Base_Stations[] base_stations { get; set; }
        public Known_Objects[] known_objects { get; set; }
        public Known_Universes[] known_universes { get; set; }
        public int revision { get; set; }
    }

    public class Base_Stations
    {
        public Config config { get; set; }
        public Dynamic_States[] dynamic_states { get; set; }
    }

    public class Config
    {
        public float[] baseCalibration { get; set; }
        public int modelId { get; set; }
        public int ootxVersion { get; set; }
        public int serialNumber { get; set; }
    }

    public class Dynamic_States
    {
        public Dynamic_State dynamic_state { get; set; }
        public int first_id { get; set; }
        public int last_id { get; set; }
        public Tilt tilt { get; set; }
        public string time_last_seen { get; set; }
    }

    public class Dynamic_State
    {
        public int basestation_mode { get; set; }
        public int faults { get; set; }
        public int firmware_version { get; set; }
        public float[] gravity_vector { get; set; }
        public int reset_count { get; set; }
        public int sobChannel { get; set; }
    }

    public class Tilt
    {
        public float pitch { get; set; }
        public float roll { get; set; }
        public float variance { get; set; }
    }

    public class Known_Objects
    {
        public string deviceClass { get; set; }
        public Imu imu { get; set; }
        public string serialNumber { get; set; }
    }

    public class Imu
    {
        public float[] acc_bias { get; set; }
        public float[] acc_scale { get; set; }
        public float[] gyro_bias { get; set; }
    }

    public class Known_Universes
    {
        public Base_Stations1[] base_stations { get; set; }
        public string id { get; set; }
        public Tilt1 tilt { get; set; }
        public int tilt_to_pose_method { get; set; }
    }

    public class Tilt1
    {
        public float pitch { get; set; }
        public float roll { get; set; }
        public float variance { get; set; }
    }

    public class Base_Stations1
    {
        public int base_serial_number { get; set; }
        public Target_Pose target_pose { get; set; }
    }

    public class Target_Pose
    {
        public float[] pose { get; set; }
        public int target_serial_number { get; set; }
        public float variance { get; set; }
    }

}
