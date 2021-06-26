using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicContainer : MonoBehaviour
{
    [Header("METRONOME")]
    public int bpm;
    [Range(1, 4)]
    public int beatLookAhead;

    [Header("MUSIC SEGMENTS")]
    public int maxMusicSegmentsToPlay;
    public AudioSource main_source;
    public AudioSource aux_source;

    //CLIPS AUDIOCLIP
    public bool playRandom;
    public bool stopOnLastTrack;
    public int beatsPerBar;
    [Tooltip("Cuentan con que hay un compás de cola")]
    public AudioClip[] music_segments;
    protected int indexSegment = -1; //Así empieza por el 0

    //CONTROL
    private bool isPlaying = false;
    private bool unlockTimeSchedulation = true;

    //CALCULOS TIEMPO
    protected double beatDuration, barDuration, beat_timeControl, nextBeatTime, startTime;


    [SerializeField] private double nextEvent, clipFinishTime, dspTime;
    protected int ouputSelector = 0;    //también lo voy a usar para cotejarlo con el maxPlaySegments

    [SerializeField] private int beatCount_int = 0;

    private void Awake()
    {
        Get_DataValues();
        if (playRandom && stopOnLastTrack)
        {
            Debug.LogError("Music container random mode and Stop on last track. Disable random mode.");
        }
    }

    private void Update()
    {
        if (!isPlaying)
            return;

        dspTime = AudioSettings.dspTime;

        if (AudioSettings.dspTime >= nextBeatTime)
        {
            Check_ResetBeatCount();
        }
        if (ouputSelector >= maxMusicSegmentsToPlay && maxMusicSegmentsToPlay > 0)
        {
            // Write stop method after number of clips are played
        }
    }

    public virtual void StartMetronome()
    {
        startTime = AudioSettings.dspTime;
        nextBeatTime = startTime + beatDuration;
        isPlaying = true;
    }

    #region Music Segments Management
    //Orden de ejecucion -----  ScheduledTime_Calculation() -> PlaySegment() -> New_IndexSegment() -> GetClipLength()
    private void ScheduledTime_Calculation()
    {

        unlockTimeSchedulation = false;
        double remainder = (AudioSettings.dspTime - startTime) % (barDuration);
        double timeToNextBar = beatLookAhead * beatDuration - remainder;
        nextEvent = AudioSettings.dspTime + timeToNextBar; //tenia puesto + beatDuration

        if (nextEvent >= clipFinishTime) //beatduration para que lo dispare
        {
            New_IndexSegment();
            PlaySegment(nextEvent);
        }
    }

    public void PlaySegment(double nextEvent)  //Este se ejecuta solo cuando ha acabado el clip
    {

        ouputSelector++;

        if (ouputSelector > music_segments.Length - 1 && stopOnLastTrack) //If we want to stop on last track
        {
            return;
        }


        if (ouputSelector % 2 == 0)
        {
            main_source.clip = music_segments[indexSegment];
            main_source.PlayScheduled(nextEvent);
        }
        else
        {
            aux_source.clip = music_segments[indexSegment];
            aux_source.PlayScheduled(nextEvent);
        }

    }

    private void New_IndexSegment() 
    {
        if (playRandom)
        {
            int prevSegment = indexSegment;
            do
            {
                indexSegment = Random.Range(1, music_segments.Length);
			} while (indexSegment == prevSegment);  //evitar repeticion

		}
        else
        {
            indexSegment++;
            if (indexSegment == music_segments.Length)
            {
                indexSegment = 1;   //para que no toque el 0 que es intro
            }
        }

        clipFinishTime = nextEvent + GetClipLength(indexSegment) - beatDuration; //le quito un bar porque si no no lo mete a tiempo

    }

    private double GetClipLength(int index)
    {
        return (double)music_segments[index].samples / music_segments[index].frequency - barDuration;
    }

    public void StopTracks()
    {
        main_source.Stop();
        aux_source.Stop();
        ResetValues();
    }
    private void ResetValues()
    {
        isPlaying = false;
        indexSegment = -1;
        ouputSelector = 0;
        nextEvent = 0;
        beatCount_int = 2;
        clipFinishTime = AudioSettings.dspTime;
    }

    IEnumerator ReturnFadeUp(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        ResetValues();
    }
    #endregion

    #region Metronome in count
    private void Check_ResetBeatCount()
    {
        nextBeatTime += beatDuration;
        beatCount_int++;
        if (beatCount_int >= (beatsPerBar - beatLookAhead) && unlockTimeSchedulation)
        {
            ScheduledTime_Calculation();
        }

        if (beatCount_int > beatsPerBar)
        {
            beatCount_int = 1;
            unlockTimeSchedulation = true;
        }
    }
    #endregion

    #region INIT
    protected void Get_DataValues()
    {
        beatDuration = 60d / bpm;
        barDuration = (60d / bpm) * 4;
    }

    #endregion
    #region ReturnVariables
    public double Get_Event()
    {
        return nextEvent;
    }
    public int Get_IndexSegment()
    {
        return indexSegment;
    }
    #endregion
}
