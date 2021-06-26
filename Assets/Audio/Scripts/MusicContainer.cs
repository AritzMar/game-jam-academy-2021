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
    public AudioSource main_sourcePiano;
    public AudioSource aux_sourcePiano;
    public AudioSource main_sourceMelody, aux_sourceMelody;
    public AudioSource main_sourcePerc, aux_sourcePerc;
    public AudioSource main_sourcePercFinal, aux_sourcePercFinal;

    //CLIPS AUDIOCLIP
    public int beatsPerBar;
    [Tooltip("Cuentan con que hay un compás de cola")]
    [Header("--CLIPS---")]
    public bool onlyOneSection;
    // Siempre suenan
    public AudioClip[] music_segmentsPiano; // uses for time calculation and so
    // Variables
    public AudioClip[] music_segmentsMelody;
    public AudioClip[] music_segmentsPerc;
    public AudioClip music_segmentPercFinal;
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

        if (ouputSelector % 2 == 0)
        {
            FillAudioSource(main_sourcePiano, main_sourceMelody, main_sourcePerc, main_sourcePercFinal,nextEvent);
        }
        else
        {
            FillAudioSource(aux_sourcePiano, aux_sourceMelody, aux_sourcePerc, aux_sourcePercFinal, nextEvent);
        }
    }
    private void FillAudioSource(AudioSource piano, AudioSource melody, AudioSource perc,AudioSource percFinal , double nextEvent_temp)
	{
        //Regular
        piano.clip = music_segmentsPiano[indexSegment];
        piano.PlayScheduled(nextEvent_temp);
        percFinal.clip = music_segmentPercFinal;
        percFinal.PlayScheduled(nextEvent_temp);

        //Variables
        if (music_segmentsMelody.Length > 1)
            melody.clip = music_segmentsMelody[Random.Range(0, music_segmentsMelody.Length - 1)];
        else
            melody.clip = music_segmentsMelody[indexSegment];
        melody.PlayScheduled(nextEvent_temp);

        if (music_segmentsPerc.Length > 1)
            perc.clip = music_segmentsPerc[Random.Range(0, music_segmentsPerc.Length - 1)];
        else
            perc.clip = music_segmentsPerc[indexSegment];
        perc.PlayScheduled(nextEvent_temp);
        perc.PlayScheduled(nextEvent_temp);


    }

    private void New_IndexSegment() 
    {
        if (!onlyOneSection)
            indexSegment++;
        else
            indexSegment = 0;
        /*
        if (indexSegment == music_segmentsPiano.Length)
        {
            indexSegment = 1;   //para que no toque el 0 que es intro
        }*/
        
        clipFinishTime = nextEvent + GetClipLength(indexSegment) - beatDuration - beatDuration * 4; //le quito un bar porque si no no lo mete a tiempo y una parte de la cola

    }

    private double GetClipLength(int index)
    {
        return (double)music_segmentsPiano[index].samples / music_segmentsPiano[index].frequency - barDuration;
    }

    public void StopTracks()
    {
        main_sourcePerc.Stop();
        main_sourcePiano.Stop();
        main_sourceMelody.Stop();
        aux_sourcePiano.Stop();
        aux_sourcePerc.Stop();
        aux_sourceMelody.Stop();
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
