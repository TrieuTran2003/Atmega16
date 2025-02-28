
#include <mega16.h>
#include <string.h>
#include <delay.h>
unsigned long ADC_out=0;
unsigned int chuc, dvi;
unsigned long nhietdo;
unsigned long dienap;
unsigned int dem=0;
int i;
int timer1 = 0xF0;
int timer2 = 0xBD;
// Standard Input/Output functions
#include <stdio.h>

#define ADC_VREF_TYPE 0x00

// Read the AD conversion result
unsigned int read_adc(unsigned char adc_input)
{
ADMUX=adc_input | (ADC_VREF_TYPE & 0xff);
// Delay needed for the stabilization of the ADC input voltage
delay_us(10);
// Start the AD conversion
ADCSRA|=0x40;
// Wait for the AD conversion to complete
while ((ADCSRA & 0x10)==0);
ADCSRA|=0x10;
return ADCW;
}

void uart_char_send(unsigned char chr){
    while (!(UCSRA &(1<<UDRE))) {};
        UDR=chr;
}

void uart_string_send(unsigned char *txt){
    unsigned char n, i;
    n=strlen(txt);
        for (i=0; i<n; i++){
        uart_char_send(txt[i]);
        }
}

// Ngat ngoai
interrupt [EXT_INT0] void ext_int1_isr(void)
{
i+=1;
chuc=(i/10);
dvi=(i%10);
uart_char_send(chuc+0x30);
uart_char_send(dvi+0x30);
uart_char_send(13);
delay_ms(200);

}

//Ngat Timer1
interrupt [TIM1_OVF] void timer1_ovf_isr(void)
{
  PORTB.0 =~PORTB.0;
  TCNT1H = timer1;
  TCNT1L = timer2;
 }
  
// Ngat UART
interrupt [USART_RXC] void usart_rx_isr(void)

{
char data;
data= UDR;

//Dieu khien thoi gian nhay den
        if(data == 'z')   
        {
           timer1=0xF0;
           timer2=0xBD;
        }
        if(data == 'x')     
        {
           timer1=0xE1;
           timer2=0x7B;
        }
        if(data == 'v')      
        {
           timer1=0xD2;
           timer2=0x39  ;
        }
        if(data == 'n')         
        {
           timer1=0xC2;
           timer2=0xF8;
        }
        if(data == 'm')          
        {
           timer1=0xB3;
           timer2=0xB4;
        }
        if(data == 'r')             
        {
           timer1=0xA4;
           timer2=0x72;
        }
        if(data == 't')              
        {
           timer1=0x95;
           timer2=0x30;
        }
        if(data == 'u')                 
        {
           timer1=0x85;
           timer2=0xED;
        }
        if(data == 'j')                  
        {
           timer1=0x76;
           timer2=0xAD;
        }
        if(data == 'k')                     
        {
           timer1=0x67;
           timer2=0x69;
        }
        
//Dieu khien den        
        if(data == '1' )
        {
            PORTC.0 = 1;  
        }     
        if(data == '2')
        {
            PORTC.1 = 1;
            }
        if ( data == '3')
        {
        PORTC.2 = 1;
        }
         if ( data == '4')
        {
        PORTC.3 = 1;
        }
         if ( data == '5')
        {
        PORTC.4 = 1;
        }
         if ( data == '6')
        {
        PORTC.5 = 1;
        }
         if ( data == '7')
        {
        PORTC.6 = 1;
        } 
         if ( data == '8')
        {
        PORTC.7 = 1;
        } 
         if(data == 'a' )
        {
            PORTC.0 = 0;  
        }        
        if(data == 'b')
        {
            PORTC.1 = 0;
            }
        if ( data == 'c')
        {
        PORTC.2 = 0;
        }
         if ( data == 'd')
        {
        PORTC.3 = 0;
        }
         if ( data == 'e')
        {
        PORTC.4 = 0;
        }
         if ( data == 'f')
        {
        PORTC.5 = 0;
        }
         if ( data == 'g')
        {
        PORTC.6 = 0;
        } 
         if ( data == 'h')
        {
        PORTC.7 = 0;
        }     


}
void main(void)
{
// Declare your local variables here

// Input/Output Ports initialization
// Port A initialization
// Func7=In Func6=In Func5=In Func4=In Func3=In Func2=In Func1=In Func0=In 
// State7=T State6=T State5=T State4=T State3=T State2=T State1=T State0=T 
PORTA=0x00;
DDRA=0x00;

// Port B initialization
// Func7=In Func6=In Func5=In Func4=In Func3=In Func2=In Func1=In Func0=In 
// State7=T State6=T State5=T State4=T State3=T State2=T State1=T State0=T 
PORTB=0x00;
DDRB=0xFF;

// Port C initialization
// Func7=In Func6=In Func5=In Func4=In Func3=In Func2=In Func1=In Func0=In 
// State7=T State6=T State5=T State4=T State3=T State2=T State1=T State0=T 
PORTC=0x00;
DDRC=0x00;

// Port D initialization
// Func7=In Func6=In Func5=In Func4=In Func3=In Func2=In Func1=In Func0=In 
// State7=T State6=T State5=T State4=T State3=T State2=T State1=T State0=T 
PORTD=0x00;
DDRD=0x00;

// Timer/Counter 0 initialization
// Clock source: System Clock
// Clock value: Timer 0 Stopped
// Mode: Normal top=0xFF
// OC0 output: Disconnected
TCCR0=0x00;
TCNT0=0x00;
OCR0=0x00;

// Timer/Counter 1 initialization
// Clock source: System Clock
// Clock value: 7.813 kHz
// Mode: Normal top=0xFFFF
// OC1A output: Discon.
// OC1B output: Discon.
// Noise Canceler: Off
// Input Capture on Falling Edge
// Timer1 Overflow Interrupt: on
// Input Capture Interrupt: Off
// Compare A Match Interrupt: Off
// Compare B Match Interrupt: Off
TCCR1A=0x00;
TCCR1B=0x05;
TCNT1H=timer1;
TCNT1L=timer2;
ICR1H=0x00;
ICR1L=0x00;
OCR1AH=0x00;
OCR1AL=0x00;
OCR1BH=0x00;
OCR1BL=0x00;

// Timer/Counter 2 initialization
// Clock source: System Clock
// Clock value: Timer2 Stopped
// Mode: Normal top=0xFF
// OC2 output: Disconnected
ASSR=0x00;
TCCR2=0x00;
TCNT2=0x00;
OCR2=0x00;

// External Interrupt(s) initialization
// INT0: On
// INT0: Falling Edge
// INT1: Off
// INT2: Off
GICR|=0x40;
MCUCR=0x02;
MCUCSR=0x00;
GIFR=0x40;

TCCR1B=0X05;
// Timer(s)/Counter(s) Interrupt(s) initialization
TIMSK=0x04;



// USART initialization
// Communication Parameters: 8 Data, 1 Stop, No Parity
// USART Receiver: On
// USART Transmitter: On
// USART Mode: Asynchronous
// USART Baud Rate: 9600
UCSRA=0x00;
UCSRB=0x98;
UCSRC=0x86;
UBRRH=0x00;
UBRRL=0x33;

// Analog Comparator initialization
// Analog Comparator: Off
// Analog Comparator Input Capture by Timer/Counter 1: Off
ACSR=0x80;
SFIOR=0x00;

// ADC initialization
// ADC Clock frequency: 1000.000 kHz
// ADC Voltage Reference: AREF pin
// ADC Auto Trigger Source: ADC Stopped
ADMUX=ADC_VREF_TYPE & 0xff;
ADCSRA=0x83;

// SPI initialization
// SPI disabled
SPCR=0x00;

// TWI initialization
// TWI disabled
TWCR=0x00;
// Global enable interrupts
#asm("sei")
while (1)
      {
      // Place your code here
        ADC_out=read_adc(0);
        dienap = ADC_out*5000/1023;
        nhietdo=dienap/10;
        chuc=nhietdo/10;
        dvi=nhietdo%10;
        uart_char_send(chuc + 0x30);
        uart_char_send(dvi + 0x30);
        uart_char_send(10);
        uart_char_send(13);
        delay_ms(200);
      }
}
