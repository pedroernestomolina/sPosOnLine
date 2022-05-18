using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Helpers
{
    
    public class Sonido
    {

        static public void SonidoOk()
        {
            var str= Properties.Resources.paso;
            using (var soundPlayer = new SoundPlayer(str)) //@"c:\Windows\Media\chimes.wav")) 
            {
                soundPlayer.Play(); // can also use soundPlayer.PlaySync()
            }
        }

        static public void ClvaeAcceso()
        {
            var str = Properties.Resources.error;
            using (var soundPlayer = new SoundPlayer(str)) //@"c:\Windows\Media\chimes.wav")) 
            {
                soundPlayer.Play(); // can also use soundPlayer.PlaySync()
            }
        }

        static public void Error()
        {
            var str = Properties.Resources.error;
            using (var soundPlayer = new SoundPlayer(str)) //@"c:\Windows\Media\chimes.wav")) 
            {
                soundPlayer.Play(); // can also use soundPlayer.PlaySync()
            }
        }

    }

}