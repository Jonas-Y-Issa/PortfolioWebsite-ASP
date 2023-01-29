window.onload = () =>{
    let container = document.querySelector("#backdrop");
    let bubbles = document.querySelectorAll(".stack_img");

    container.width = innerWidth;
    container.height = innerHeight;

class Bubble{
    constructor(speed, friction, bubble, ind){
        this.speed = speed;
        this.friction = friction;
        this.bubble = bubble;
        this.ind = ind;
        this.play = true;
        this.positionQuadratic(ind*0.1);
    }
    positionCurve(){
        this.bubble.style.top = this.ind * 84 + "px";
        this.bubble.style.left = 
        (container.width )
        -(84*(container.width/Math.abs(container.height-this.bubble.offsetTop)))
        + "px";
    }    
    positionDefault(){
        this.bubble.style.top = (1.5+this.ind) * 90 + "px";
        this.bubble.style.left = container.width - 120 +"px";
    }
    positionQuadratic(i){
        var x1 = container.width-(this.bubble.clientWidth);
        var y1 = 0;
        var x2 = container.width-(this.bubble.clientWidth);
        var y2 = container.height-(this.bubble.clientHeight);
        var x3 = 0;
        var y3 = container.height-(this.bubble.clientHeight);
        var xa = this.getPt(x1, x2, i);
        var ya = this.getPt(y1, y2, i);
        var xb = this.getPt(x2, x3, i);
        var yb = this.getPt(y2, y3, i);
    
        var y = this.getPt(xa ,xb ,i);
        var x = this.getPt(ya ,yb ,i);
        this.bubble.style.top = x + "px";
        this.bubble.style.left = y + "px";
    }
    moveQuadratic(i){
        var x1 = container.width/(container.width/container.height);
        var y1 = 0;
        var x2 = container.width/(container.width/container.height);
        var y2 = container.height-200;
        var x3 = 0;
        var y3 = container.height-200;
        var xa = this.getPt(x1, x2, i);
        var ya = this.getPt(y1, y2, i);
        var xb = this.getPt(x2, x3, i);
        var yb = this.getPt(y2, y3, i);
    
        var y = this.getPt(xa ,xb ,i);
        var x = this.getPt(ya ,yb ,i);
        this.bubble.style.top = x + "px";
        this.bubble.style.left = y + "px";
    }
    getPt(n1, n2, perc){
        var diff = n2 - n1;
        return n1 + (diff * perc);
    }   
    moveCSS(){
        this.bubble.animate([
            { transform: 'scale(1)', background: 'red', opacity: 1, offset: 0 },
            { transform: 'scale(.5) rotate(270deg)', background: 'blue', opacity: .5, offset: .2 },
            { transform: 'scale(1) rotate(0deg)', background: 'red', opacity: 1, offset: 1 },
          ], {
            duration: 2000, //milliseconds
            easing: 'ease-in-out', //'linear', a bezier curve, etc.
            delay: 10, //milliseconds
            iterations: Infinity, //or a number
            direction: 'alternate', //'normal', 'reverse', etc.
            fill: 'forwards' //'backwards', 'both', 'none', 'auto'
          });
    }    
    move(){
        this.speed+=0.01;
        this.moveQuadratic(this.speed);

        if (this.bubble.offsetLeft + (this.bubble.offsetWidth/2) <= (this.ind) * (this.bubble.offsetWidth)){ 
            this.play = false;
            return;
        }
    }
}
    let bubble_list = [];
    var i = -1;
    bubbles.forEach(bubble => {
        i += 1;
        bubble_list.push(new Bubble(0,.09, bubble, i));
    });

    function animate(){
        requestAnimationFrame(animate);
        bubble_list.forEach(bubble => {
            if (bubble.play){
                bubble.move();
            }
        });
    }
    animate();
}